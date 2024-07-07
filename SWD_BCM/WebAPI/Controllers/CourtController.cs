using Application.Interfaces;
using Application.Services;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.RoleDTOs;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize (Roles = "Manager")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCourt([FromBody] CourtCreateDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest();
            }
            var c = await _courtService.CreateCourtAsync(createDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCourt(int id, [FromBody] CourtUpdateDTO updateDto)
        {
            var c = await _courtService.UpdateCourtAsync(id, updateDto);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }

        [Authorize(Roles = "Manager, Customer")]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCourt(int id)
        {
            var c = await _courtService.DeleteCourtAsync(id);
            if (!c.Success)
            {
                return BadRequest(c);
            }
            return Ok(c);
        }
    }
}
