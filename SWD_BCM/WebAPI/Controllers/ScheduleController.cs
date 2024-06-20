using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ScheduleController: BaseController
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService schedulService)
        {
            _scheduleService = schedulService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllSchedules()
        {
            var result = await _scheduleService.GetSchedulesAsync();
            return Ok(result);
        }
    }
}
