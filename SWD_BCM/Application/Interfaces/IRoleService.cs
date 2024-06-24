using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.ScheduleDTOs;


namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<RoleDTO>>> GetRolesAsync();
        Task<ServiceResponse<RoleDTO>> GetSRoleByIdAsync(int id);
        Task<ServiceResponse<List<RoleDTO>>> SearchRoleByNameAsync(string name);
        Task<ServiceResponse<RoleDTO>> DeleteRoleAsync(int id);
        Task<ServiceResponse<RoleDTO>> UpdateRoleAsync(int id, RoleUpdateDTO updateDto);
        Task<ServiceResponse<RoleDTO>> CreateRoleAsync(RoleCreateDTO role);
    }
}
