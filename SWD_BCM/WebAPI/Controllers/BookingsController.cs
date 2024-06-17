using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BookingsController : BaseController
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService) 
        {
            _bookingService = bookingService;
        }
    }
}
