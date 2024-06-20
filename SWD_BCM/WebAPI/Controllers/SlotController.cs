using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class SlotController: BaseController
    {
        private readonly ISlotService _slotService;
        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllSlots()
        {
            var result = await _slotService.GetSlotsAsync();
            return Ok(result);
        }
    }
}
