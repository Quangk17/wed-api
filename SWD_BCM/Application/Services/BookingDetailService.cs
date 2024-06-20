using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.BookingDetailDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<BookingDetailViewDTO>> CreateBookingDetailAsync(BookingDetailCreateDTO createdto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<BookingDetailViewDTO>> GetBookingDetailByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<BookingDetailViewDTO>>> GetBookingDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<BookingDetailViewDTO>>> GetBookingDetailsByBookingIDAsync(int BookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<BookingDetailViewDTO>>> GetSortedBookingDetailsAsync(string sortName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<BookingDetailViewDTO>> SetStatusActiveBookingDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<BookingDetailViewDTO>> UpdateBookingDetailAsync(int id, BookingDetailUpdateDTO updatedto)
        {
            throw new NotImplementedException();
        }
    }
}
