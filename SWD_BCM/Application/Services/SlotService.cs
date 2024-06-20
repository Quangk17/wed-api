using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.SlotDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SlotService: ISlotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SlotService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<SlotDTO>>> GetSlotsAsync()
        {
            var reponse = new ServiceResponse<List<SlotDTO>>();
            List<SlotDTO> SlotDTOs = new List<SlotDTO>();
            try
            {
                var a = await _unitOfWork.SlotRepository.GetAllAsync();
                foreach (var ac in a)
                {
                    var aaftermapper = _mapper.Map<SlotDTO>(ac);
                    aaftermapper.name = ac.name;
                    SlotDTOs.Add(aaftermapper);
                }
                if (SlotDTOs.Count > 0)
                {
                    reponse.Data = SlotDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {SlotDTOs.Count} slots.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {SlotDTOs.Count} slots.";
                    reponse.Error = "Not have a slot";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.Error = "Exception";
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }
        }
    }
}
