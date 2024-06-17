using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;


namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<List<AccountDTO>>> GetAccountsAsync();
        Task<ServiceResponse<AccountDTO>> GetAccountByIdAsync(int id);
        Task<ServiceResponse<List<AccountDTO>>> SearchAccountByNameAsync(string name);
        Task<ServiceResponse<AccountDTO>> DeleteAccountAsync(int id);
        Task<ServiceResponse<AccountDTO>> UpdateAccountAsync(int id, AccountUpdateDTO updateDto);
    }
}
