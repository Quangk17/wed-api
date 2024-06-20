using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.RoleDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CourtService : ICourtService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourtService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CourtDTO>>> GetCourtsAsync()
        {
            var response = new ServiceResponse<List<CourtDTO>>();
            List<CourtDTO> CourtDTOs = new List<CourtDTO>();
            try
            {
                var courts = await _unitOfWork.CourtRepository.GetCourtsAsync();

                foreach (var court in courts)
                {
                    var courtDto = _mapper.Map<CourtDTO>(court);
                    courtDto.Name = court.Name;
                    CourtDTOs.Add(courtDto);
                }
                if (CourtDTOs.Count > 0)
                {
                    response.Data = CourtDTOs;
                    response.Success = true;
                    response.Message = $"Have {CourtDTOs.Count} roles.";
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
