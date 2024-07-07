﻿using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.InvoiceDTOs;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.ScheduleDTOs;
using AutoMapper;
using Domain.Entites;
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

        public async Task<ServiceResponse<CourtDTO>> CreateCourtAsync(CourtCreateDTO createdto)
        {
            var reponse = new ServiceResponse<CourtDTO>();

            try
            {
                var entity = _mapper.Map<Court>(createdto);

                await _unitOfWork.CourtRepository.AddAsync(entity);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    reponse.Data = _mapper.Map<CourtDTO>(entity);
                    reponse.Success = true;
                    reponse.Message = "Create new Court successfully";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = "Create new Court fail";
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

        public async Task<ServiceResponse<CourtDTO>> DeleteCourtAsync(int id)
        {
            var _response = new ServiceResponse<CourtDTO>();
            var court = await _unitOfWork.CourtRepository.GetByIdAsync(id);

            if (court != null)
            {
                _unitOfWork.CourtRepository.SoftRemove(court);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    _response.Data = _mapper.Map<CourtDTO>(court);
                    _response.Success = true;
                    _response.Message = "Deleted Court Successfully!";
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Deleted Court Fail!";
                }
            }
            else
            {
                _response.Success = false;
                _response.Message = "Court not found";
            }

            return _response;
        }

        public Task<ServiceResponse<CourtDTO>> GetCourtByIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public async Task<ServiceResponse<CourtDTO>> UpdateCourtAsync(int id, CourtUpdateDTO updatedto)
        {
            var reponse = new ServiceResponse<CourtDTO>();

            try
            {
                var enityById = await _unitOfWork.CourtRepository.GetByIdAsync(id);

                if (enityById != null)
                {
                    var newb = _mapper.Map(updatedto, enityById);
                    var bAfter = _mapper.Map<Court>(newb);
                    _unitOfWork.CourtRepository.Update(bAfter);
                    if (await _unitOfWork.SaveChangeAsync() > 0)
                    {
                        reponse.Success = true;
                        reponse.Data = _mapper.Map<CourtDTO>(bAfter);
                        reponse.Message = $"Successfull for update Court.";
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
                    reponse.Message = $"Have no Court.";
                    reponse.Error = "Not have a Court";
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
