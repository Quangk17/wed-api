using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.RoleDTOs;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<RoleDTO>>> GetRolesAsync()
        {
            var response = new ServiceResponse<List<RoleDTO>>();
            List<RoleDTO> RolesDTOs = new List<RoleDTO>();
            try
            {
                var roles = await _unitOfWork.RoleRepository.GetRolesAsync();
                
                foreach (var role in roles)
                {
                    var roleDto = _mapper.Map<RoleDTO>(role);
                    roleDto.RoleName = role.RoleName;
                    RolesDTOs.Add(roleDto);
                }
                if (RolesDTOs.Count > 0)
                {
                    response.Data = RolesDTOs;
                    response.Success = true;
                    response.Message = $"Have {RolesDTOs.Count} roles.";
                    response.Error = "No error";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No roles found.";
                    response.Error = "No roles available";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = "Exception";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            return response;
        }

    }

}
