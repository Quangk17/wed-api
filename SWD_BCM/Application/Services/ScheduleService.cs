using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.ScheduleDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ScheduleService: IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScheduleService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ScheduleDTO>>> GetSchedulesAsync()
        {
            var response = new ServiceResponse<List<ScheduleDTO>>();
            List<ScheduleDTO> ScheduleDTOs = new List<ScheduleDTO>();
            try
            {
                var schedules = await _unitOfWork.ScheduleRepository.GetSchedulesAsync();

                foreach (var schedule in schedules)
                {
                    var scheduleDto = _mapper.Map<ScheduleDTO>(schedule);
                    scheduleDto.date = schedule.date;
                    ScheduleDTOs.Add(scheduleDto);
                }
                if (ScheduleDTOs.Count > 0)
                {
                    response.Data = ScheduleDTOs;
                    response.Success = true;
                    response.Message = $"Have {ScheduleDTOs.Count} schedules.";
                    response.Error = "No error";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No schedules found.";
                    response.Error = "No schedules available";
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
