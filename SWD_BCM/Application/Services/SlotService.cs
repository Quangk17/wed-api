using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.InvoiceDTOs;
using Application.ViewModels.SlotDTOs;
using AutoMapper;
using Domain.Entites;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<ServiceResponse<SlotDTO>> CreateSlotsync(SlotCreateDTO slot)
        {
            var reponse = new ServiceResponse<SlotDTO>();

            try
            {
                var entity = _mapper.Map<Slot>(slot);

                await _unitOfWork.SlotRepository.AddAsync(entity);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<SlotDTO>(entity);
                    reponse.Success = true;
                    reponse.Message = "Create new Slot successfully";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = "Create new Slot fail";
                    return reponse;
                }
            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }

        public async Task<ServiceResponse<SlotDTO>> DeleteSlotAsync(int id)
        {
            var _response = new ServiceResponse<SlotDTO>();
            var slot = await _unitOfWork.SlotRepository.GetByIdAsync(id);

            if (slot != null)
            {
                _unitOfWork.SlotRepository.SoftRemove(slot);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    _response.Data = _mapper.Map<SlotDTO>(slot);
                    _response.Success = true;
                    _response.Message = "Deleted Slot Successfully!";
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Deleted Slot Fail!";
                }
            }
            else
            {
                _response.Success = false;
                _response.Message = "Slot not found";
            }

            return _response;
        }

        public Task<ServiceResponse<SlotDTO>> GetSlotByIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<ServiceResponse<List<SlotDTO>>> SearchSlotByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<SlotDTO>> UpdateSlotAsync(int id, SlotUpdateDTO updateDto)
        {
            var reponse = new ServiceResponse<SlotDTO>();

            try
            {
                var enityById = await _unitOfWork.SlotRepository.GetByIdAsync(id);

                if (enityById != null)
                {
                    var newb = _mapper.Map(updateDto, enityById);
                    var bAfter = _mapper.Map<Slot>(newb);
                    _unitOfWork.SlotRepository.Update(bAfter);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Success = true;
                        reponse.Data = _mapper.Map<SlotDTO>(bAfter);
                        reponse.Message = $"Successfull for update Slot.";
                        return reponse;
                    }
                    else
                    {
                        reponse.Success = false;
                        reponse.Error = "Save update failed";
                        return reponse;
                    }

                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have no Slot.";
                    reponse.Error = "Not have a Slot";
                    return reponse;
                }

            }
            catch (Exception ex)
            {
                reponse.Success = false;
                reponse.ErrorMessages = new List<string> { ex.Message };
                return reponse;
            }

            return reponse;
        }
    }
}
