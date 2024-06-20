using Application.ServiceResponses;
using Application.ViewModels.StoreDTOs;


namespace Application.Interfaces
{
    public interface IStoreService
    {
        Task<ServiceResponse<List<StoreDTO>>> GetStoresAsync();
    }
}
