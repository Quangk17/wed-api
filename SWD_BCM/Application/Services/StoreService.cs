using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.StoreDTOs;
using AutoMapper;


namespace Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<StoreDTO>> CreateStoreAsync(StoreCreateDTO store)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<StoreDTO>> DeleteStoreAsync(int id)
        {
            var _response = new ServiceResponse<StoreDTO>();
            var store = await _unitOfWork.StoreRepository.GetByIdAsync(id);

            if (store != null)
            {
                _unitOfWork.StoreRepository.SoftRemove(store);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    _response.Data = _mapper.Map<StoreDTO>(store);
                    _response.Success = true;
                    _response.Message = "Deleted store Successfully!";
                }
                else
                {
                    _response.Success = false;
                    _response.Message = "Deleted store Fail!";
                }
            }
            else
            {
                _response.Success = false;
                _response.Message = "Store not found";
            }

            return _response;
        }

        public Task<ServiceResponse<StoreDTO>> GetStoreByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<StoreDTO>>> GetStoresAsync()
        {
            var reponse = new ServiceResponse<List<StoreDTO>>();
            List<StoreDTO> StoreDTOs = new List<StoreDTO>();
            try
            {
                var a = await _unitOfWork.StoreRepository.GetStoresAsync();
                foreach (var ac in a)
                {
                    var aaftermapper = _mapper.Map<StoreDTO>(ac);
                    aaftermapper.name = ac.name;
                    StoreDTOs.Add(aaftermapper);
                }
                if (StoreDTOs.Count > 0)
                {
                    reponse.Data = StoreDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {StoreDTOs.Count} stores.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {StoreDTOs.Count} stores.";
                    reponse.Error = "Not have a store";
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

        public Task<ServiceResponse<List<StoreDTO>>> SearchStoreByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<StoreDTO>> UpdateStoreAsync(int id, StoreUpdateDTO updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
