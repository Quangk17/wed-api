using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.RoleDTOs;


namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<ServiceResponse<List<RoleDTO>>> GetRolesAsync();
    }
}
