using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<ServiceResponse<AccountDTO>> RegisterAsync(RegisterAccountDTO registerAccountDTO);
        public Task<ServiceResponse<string>> LoginAsync(AuthenAccountDTO accountDto);
    }

}
