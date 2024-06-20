using Application.ServiceResponses;
using Application.ViewModels.BookingTypeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookingTypeService 
    {
        Task<ServiceResponse<IEnumerable<BookingTypeViewDTO>>> GetBookingTypesAsync();
        Task<ServiceResponse<BookingTypeViewDTO>> GetBookingTypeByIdAsync(int id);
        Task<ServiceResponse<BookingTypeViewDTO>> CreateBookingTypeAsync(BookingTypeCreateDTO createdto);
        Task<ServiceResponse<BookingTypeViewDTO>> UpdateBookingTypeAsync(int id, BookingTypeUpdateDTO updatedto);
        Task<ServiceResponse<BookingTypeViewDTO>> DeleteBookingTypeAsync(int id);
        Task<ServiceResponse<IEnumerable<BookingTypeViewDTO>>> GetSortedBookingTypesAsync(string sortName);
    }
}
