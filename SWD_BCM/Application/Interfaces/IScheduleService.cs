using Application.ServiceResponses;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.ScheduleDTOs;
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
    }
}
