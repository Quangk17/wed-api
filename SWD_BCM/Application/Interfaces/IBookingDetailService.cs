using Application.ServiceResponses;
using Application.ViewModels.BookingDetailDTOs;
using Application.ViewModels.BookingDTOs;


namespace Application.Interfaces
{
    public interface IBookingDetailService
    {
        Task<ServiceResponse<IEnumerable<BookingDetailViewDTO>>> GetBookingDetailsAsync();
        Task<ServiceResponse<BookingDetailViewDTO>> GetBookingDetailByIdAsync(int Id);
        Task<ServiceResponse<IEnumerable<BookingDetailViewDTO>>> GetBookingDetailsByBookingIDAsync(int BookingId);
        Task<ServiceResponse<BookingDetailViewDTO>> UpdateBookingDetailAsync(int id, BookingDetailUpdateDTO updatedto);
        Task<ServiceResponse<BookingDetailViewDTO>> SetStatusActiveBookingDetailAsync(int id);
        Task<ServiceResponse<IEnumerable<BookingDetailViewDTO>>> GetSortedBookingDetailsAsync(string sortName);
    }
}
