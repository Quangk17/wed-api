using Application.ServiceResponses;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.ScheduleDTOs;
using Application.ViewModels.SlotDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IScheduleService
    {
        Task<ServiceResponse<List<ScheduleDTO>>> GetSchedulesAsync();
        Task<ServiceResponse<ScheduleDTO>> GetScheduleByIdAsync(int id);
        Task<ServiceResponse<List<ScheduleDTO>>> SearchScheduleByNameAsync(string name);
        Task<ServiceResponse<ScheduleDTO>> DeleteScheduleAsync(int id);
        Task<ServiceResponse<ScheduleDTO>> UpdateScheduleAsync(int id, ScheduleUpdateDTO updateDto);
        Task<ServiceResponse<ScheduleDTO>> CreateScheduleAsync(ScheduleCreateDTO schedule);
    }
}
