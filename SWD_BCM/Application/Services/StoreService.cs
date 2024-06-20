using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
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
    }
}
