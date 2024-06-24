using Application.ServiceResponses;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.SlotDTOs;
using Application.ViewModels.StoreDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISlotService
    {
        Task<ServiceResponse<List<SlotDTO>>> GetSlotsAsync();
        Task<ServiceResponse<SlotDTO>> GetSlotByIdAsync(int id);
        Task<ServiceResponse<List<SlotDTO>>> SearchSlotByNameAsync(string name);
        Task<ServiceResponse<SlotDTO>> DeleteSlotAsync(int id);
        Task<ServiceResponse<SlotDTO>> UpdateSlotAsync(int id, SlotUpdateDTO updateDto);
        Task<ServiceResponse<SlotDTO>> CreateSlotsync(SlotCreateDTO slot);
    }
}
