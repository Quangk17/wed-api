using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;


namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<List<AccountDTO>>> GetAccountsAsync();
    }
}
