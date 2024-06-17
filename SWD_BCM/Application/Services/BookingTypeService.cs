using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.BookingTypeDTOs;
using AutoMapper;
using Domain.Entites;
using MailKit.Search;
using Org.BouncyCastle.Asn1.X509;

namespace Application.Services
{
    public class BookingTypeService : IBookingTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingTypeService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<BookingTypeViewDTO>> CreateBookingTypeAsync(BookingTypeCreateDTO createdto)
        {
            var reponse = new ServiceResponse<BookingTypeViewDTO>();

            try
            {
                var entity = _mapper.Map<BookingType>(createdto);

                await _unitOfWork.BookingTypeRepository.AddAsync(entity);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<BookingTypeViewDTO>(entity);
                    reponse.Success = true;
                    reponse.Message = "Create new bookingType successfully";
                    reponse.Error = string.Empty;
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }

        public async Task<ServiceResponse<BookingTypeViewDTO>> DeleteBookingTypeAsync(int id)
        {
            var reponse = new ServiceResponse<BookingTypeViewDTO>();
            try
            {
                var Checked = await _unitOfWork.BookingTypeRepository.GetByIdAsync(id);

                if (Checked == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Not found bookingtype, you are sure input";
                    reponse.Error = "Not found bookingtype";
                }
                else if (Checked.IsDeleted == true)
                {
                    reponse.Success = false;
                    reponse.Message = "bookingtype are deleted, can not delete bookingtype.";
                }
                else
                {

                        _unitOfWork.BookingTypeRepository.SoftRemove(Checked);
                        if (await _unitOfWork.SaveChangeAsync() > 0)
                        {
                            reponse.Success = true;
                            reponse.Message = "Update bookingtype successfully";
                        }
                        else
                        {
                            reponse.Success = false;
                            reponse.Message = "Update bookingtype fail!";
                        }
                }
            }
            catch (Exception e)
            {
                reponse.Success = false;
                reponse.Message = "Update bookingtype fail!, exception";
                reponse.ErrorMessages = new List<string> { e.Message };
            }

            return reponse;
        }

        public async Task<ServiceResponse<BookingTypeViewDTO>> GetBookingTypeByIdAsync(int id)
        {
            var _response = new ServiceResponse<BookingTypeViewDTO>();
            try
            {
                var c = await _unitOfWork.BookingTypeRepository.GetByIdAsync(id);
                if (c == null)
                {
                    _response.Success = false;
                    _response.Message = "Don't Have Any Booking Type ";
                }
                else
                {
                    _response.Data = _mapper.Map<BookingTypeViewDTO>(c);
                    _response.Success = true;
                    _response.Message = "Booking Type Retrieved Successfully";
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        public async Task<ServiceResponse<IEnumerable<BookingTypeViewDTO>>> GetBookingTypesAsync()
        {
            var reponse = new ServiceResponse<IEnumerable<BookingTypeViewDTO>>();
            List<BookingTypeViewDTO> BookingTypeDTOs = new List<BookingTypeViewDTO>();
            try
            {
                var bs = await _unitOfWork.BookingTypeRepository.GetAllAsync();
                foreach (var b in bs)
                {
                    BookingTypeDTOs.Add(_mapper.Map<BookingTypeViewDTO>(b));
                }
                if (BookingTypeDTOs.Count > 0)
                {
                    reponse.Data = BookingTypeDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {BookingTypeDTOs.Count} Booking Type.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {BookingTypeDTOs.Count} Booking Type.";
                    reponse.Error = "Not have a Booking Type";
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

        public Task<ServiceResponse<IEnumerable<BookingTypeViewDTO>>> GetSortedBookingTypesAsync(string sortName)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<BookingTypeViewDTO>> UpdateBookingTypeAsync(int id, BookingTypeUpdateDTO updatedto)
        {
            var reponse = new ServiceResponse<BookingTypeViewDTO>();

            try
            {
                var enityById = await _unitOfWork.BookingTypeRepository.GetByIdAsync(id);

                if (enityById != null)
                {
                    var newb = _mapper.Map(updatedto, enityById);
                    var bAfter = _mapper.Map<BookingType>(newb);
                    _unitOfWork.BookingTypeRepository.Update(bAfter);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Success = true;
                        reponse.Data = _mapper.Map<BookingTypeViewDTO>(bAfter);
                        reponse.Message = $"Successfull for update Booking Type.";
                        return reponse;
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Error = "Save update failed";
                        return reponse;
                    }

                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have no Booking Type.";
                    reponse.Error = "Not have a Booking Type";
                    return reponse;
                }

            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }
    }
}
