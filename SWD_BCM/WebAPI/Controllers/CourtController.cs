using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CourtController: BaseController
    {
        private readonly ICourtService _courtService;
        public CourtController(ICourtService courtService)
        {
            _courtService =courtService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllCourts()
        {
            var result = await _courtService.GetCourtsAsync();
            return Ok(result);
        }
    }
}
