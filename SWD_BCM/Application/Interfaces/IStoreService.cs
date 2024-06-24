using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.BookingDTOs;
using Application.ViewModels.StoreDTOs;


namespace Application.Interfaces
{
    public interface IStoreService
    {
        Task<ServiceResponse<List<StoreDTO>>> GetStoresAsync();
        Task<ServiceResponse<StoreDTO>> GetStoreByIdAsync(int id);
        Task<ServiceResponse<List<StoreDTO>>> SearchStoreByNameAsync(string name);
        Task<ServiceResponse<StoreDTO>> DeleteStoreAsync(int id);
        Task<ServiceResponse<StoreDTO>> UpdateStoreAsync(int id, StoreUpdateDTO updateDto);
        Task<ServiceResponse<StoreDTO>> CreateStoreAsync(StoreCreateDTO store);

    }
}
