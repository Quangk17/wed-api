using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.BookingDTOs;
using Application.ViewModels.InvoiceDTOs;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BookingViewDTO>> CancelBookingAsync(int id)
        {
            var reponse = new ServiceResponse<BookingViewDTO>();
            try
            {
                var bookingChecked = await _unitOfWork.BookingRepository.GetByIdAsync(id, x => x.User , x => x.BookingType);

                if (bookingChecked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found booking, you are sure input";
                    reponse.Error = "Not found booking";
                }
                else if (bookingChecked.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Message = "booking are deleted, can not cancel booking.";
                }
                else if (bookingChecked.StatusPayment == true)
                {
                    reponse.Success = false;
                    reponse.Message = "booking is paymented, can not cancel booking.";
                }
                else
                {
                        bookingChecked.IsDeleted = true;
                        var bookingFofUpdate = _mapper.Map<BookingViewDTO>(bookingChecked);
                        var bookingDTOAfterUpdate = _mapper.Map<BookingViewDTO>(bookingFofUpdate);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Data = bookingDTOAfterUpdate;
                            reponse.Success = true;
                            reponse.Message = "Update booking successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update booking fail!";
                        }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update order fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<BookingViewDTO>> CreateBookingAsync(BookingCreateDTO createdto)
        {
            var response = new ServiceResponse<BookingViewDTO>();

            try
            {
                var entity = _mapper.Map<Booking>(createdto);

                await _unitOfWork.BookingRepository.AddAsync(entity);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    Booking entityAfterAdd = await _unitOfWork.BookingRepository.GetByIdAsync(entity.Id, x => x.User, x => x.BookingType);

                    if (entityAfterAdd != null)
                    {
                        var mapperdto = _mapper.Map<BookingViewDTO>(entityAfterAdd);
                        mapperdto.UserName = entityAfterAdd.User?.name;
                        mapperdto.BookingTypeName = entityAfterAdd.BookingType?.name;

                        response.Data = mapperdto;
                        response.Success = true;
                        response.Message = "Created new booking successfully";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Booking created but not found in the database.";
                        response.Error = "Booking retrieval failed.";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed to create new booking.";
                    response.Error = "Database save failed.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while creating the booking.";
                response.ErrorMessages = new List<string> { ex.Message };
            }

            return response;
        }

        public async Task<ServiceResponse<BookingViewDTO>> GetBookingByIdAsync(int BookingId)
        {
            var _response = new ServiceResponse<BookingViewDTO>();
            try
            {
                var c = await _unitOfWork.BookingRepository.GetByIdAsync(BookingId);
                if (c == null)
                {
                    _response.Success = false;
                    _response.Message = "Don't Have Any Booking ";
                }
                else
                {
                    _response.Data = _mapper.Map<BookingViewDTO>(c);
                    _response.Success = true;
                    _response.Message = "Booking Retrieved Successfully";
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        public async Task<ServiceResponse<IEnumerable<BookingViewDTO>>> GetBookingByUserIDAsync(int userId)
        {
            var reponse = new ServiceResponse<IEnumerable<BookingViewDTO>>();
            List<BookingViewDTO> BookingDTOs = new List<BookingViewDTO>();
            try
            {
                var bookings = await _unitOfWork.BookingRepository.GetAllAsync(x => x.User, x => x.BookingType);
                foreach (var booking in bookings)
                {
                    if(booking.UserID == userId)
                    {
                        var mapper = _mapper.Map<BookingViewDTO>(booking);
                        mapper.UserName = booking.User.name;
                        mapper.BookingTypeName = booking.BookingType.name;
                        BookingDTOs.Add(mapper);
                    }
                }
                if (BookingDTOs.Count > 0)
                {
                    reponse.Data = BookingDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {BookingDTOs.Count} bookings.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {BookingDTOs.Count} bookings.";
                    reponse.Error = "Not have a bookings";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Error = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        public async Task<ServiceResponse<IEnumerable<BookingViewDTO>>> GetBookingsAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<BookingViewDTO>>();
            List<BookingViewDTO> BookingDTOs = new List<BookingViewDTO>();
            try
            {
                var bookings = await _unitOfWork.BookingRepository.GetAllAsync(x => x.User, x=> x.BookingType);
                foreach (var booking in bookings)
                {
                    var mapper = _mapper.Map<BookingViewDTO>(booking);
                    mapper.UserName = booking.User.name;
                    mapper.BookingTypeName = booking.BookingType.name;
                    BookingDTOs.Add(mapper);
                }
                if (BookingDTOs.Count > 0)
                {
                    reponse.Data = BookingDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {BookingDTOs.Count} bookings.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {BookingDTOs.Count} bookings.";
                    reponse.Error = "Not have a bookings";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Error = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }

        public async Task<ServiceResponse<IEnumerable<BookingViewDTO>>> GetSortedBookingsAsync(string sortName)
        {
            var response = new ServiceResponse<IEnumerable<BookingViewDTO>>();

            try
            {
                var bookings = await _unitOfWork.BookingRepository.GetAllAsync();

                if (bookings == null || !bookings.Any())
                {
                    response.Success = false;
                    response.Error = "No bookings found";
                    return response;
                }

                IEnumerable<Booking> sortedBookings = sortName.ToLower() switch
                {
                    "a-z" => bookings.OrderBy(b => b.BookingName),
                    "z-a" => bookings.OrderByDescending(b => b.BookingName),
                    "asc" => bookings.OrderBy(b => b.BookingDate),
                    "desc" => bookings.OrderByDescending(b => b.BookingDate),
                    _ => bookings
                };

                var bookingViewDTOs = _mapper.Map<IEnumerable<BookingViewDTO>>(sortedBookings);
                response.Success = true;
                response.Data = bookingViewDTOs;
                response.Message = "Bookings retrieved and sorted successfully.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessages = new List<string> { ex.Message };
            }

            return response;
        }
        
        public async Task<ServiceResponse<BookingViewDTO>> UpdateBookingAsync(int id, BookingUpdateDTO dto)
        {
            var response = new ServiceResponse<BookingViewDTO>();

            try
            {
                var entityById = await _unitOfWork.BookingRepository.GetByIdAsync(id);

                if (entityById == null)
                {
                    response.Success = false;
                    response.Error = "Not have a Booking";
                    response.Message = "Have no Booking.";
                    return response;
                }

                _mapper.Map(dto, entityById);
                _unitOfWork.BookingRepository.Update(entityById);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    response.Success = true;
                    response.Data = _mapper.Map<BookingViewDTO>(entityById);
                    response.Message = "Successfully updated Booking.";
                    return response;
                }

                response.Success = false;
                response.Error = "Save update failed";
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return response;
            }
        }

    }
}
