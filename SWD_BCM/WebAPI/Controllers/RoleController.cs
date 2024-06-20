using Application.Interfaces;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RoleController: BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ViewAllRoles()
        {
            var result = await _roleService.GetRolesAsync();
            return Ok(result);
        }
    }
}
