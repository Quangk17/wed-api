using Application.ServiceResponses;
using Application.ViewModels.BookingDTOs;


namespace Application.Interfaces
{
    public interface IBookingService
    {
        Task<ServiceResponse<IEnumerable<BookingViewDTO>>> GetBookingsAsync();
        Task<ServiceResponse<BookingViewDTO>> GetBookingByIdAsync(int BookingId);
        Task<ServiceResponse<IEnumerable<BookingViewDTO>>> GetBookingByUserIDAsync(int userId);
        Task<ServiceResponse<BookingViewDTO>> CreateBookingAsync(BookingCreateDTO Booking);
        Task<ServiceResponse<BookingViewDTO>> UpdateBookingAsync(int id, BookingUpdateDTO Booking);
        Task<ServiceResponse<BookingViewDTO>> CancelBookingAsync(int id);
        Task<ServiceResponse<IEnumerable<BookingViewDTO>>> GetSortedBookingsAsync(string sortName);
    }
}
