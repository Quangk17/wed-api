using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.ScheduleDTOs;
using Application.ViewModels.SlotDTOs;
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

        public Task<ServiceResponse<ScheduleDTO>> CreateScheduleAsync(ScheduleCreateDTO schedule)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<ScheduleDTO>> DeleteScheduleAsync(int id)
        {
            var _response = new ServiceResponse<ScheduleDTO>();
            var schedule = await _unitOfWork.ScheduleRepository.GetByIdAsync(id);

            if (schedule != null)
            {
                _unitOfWork.ScheduleRepository.SoftRemove(schedule);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    _response.Data = _mapper.Map<ScheduleDTO>(schedule);
                    _response.Success = true;
                    _response.Message = "Deleted Schedule Successfully!";
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Deleted Schedule Fail!";
                }
            }
            else
            {
                _response.Success = false;
                _response.Message = "Schedule not found";
            }

            return _response;
        }

        public Task<ServiceResponse<ScheduleDTO>> GetScheduleByIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<ServiceResponse<List<ScheduleDTO>>> SearchScheduleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ScheduleDTO>> UpdateScheduleAsync(int id, ScheduleUpdateDTO updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
