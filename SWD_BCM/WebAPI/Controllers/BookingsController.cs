using Application.Interfaces;
using Application.Services;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.BookingDTOs;
using Application.ViewModels.InvoiceDTOs;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllBooking()
        {
            var result = await _bookingService.GetBookingsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBookingByID(int Id)
        {
            var result = await _bookingService.GetBookingByIdAsync(Id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewBookingByUser(int id)
        {
            var result = await _bookingService.GetBookingByUserIDAsync(id);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingUpdateDTO updateDto)
        {
            var c = await _bookingService.UpdateBookingAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var c = await _bookingService.CancelBookingAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            var c = await _bookingService.CreateBookingAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }


    }
}
