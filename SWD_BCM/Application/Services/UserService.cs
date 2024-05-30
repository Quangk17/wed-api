
using Application.Commons;
using Application.Interfaces;
using Application.ServiceResponses;
using Application.ViewModels.AccountDTOs;
using AutoMapper;
using Domain.Entites;
namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<AccountDTO>>> GetAccountsAsync()
        {
            var reponse = new ServiceResponse<List<AccountDTO>>();
            List<AccountDTO> UserDTOs = new List<AccountDTO>();
            try
            {
                var a = await _unitOfWork.AccountRepository.GetAccountsAsync();
                foreach (var ac in a)
                {
                    var aaftermapper = _mapper.Map<AccountDTO>(ac);
                    UserDTOs.Add(aaftermapper);
                }
                if (UserDTOs.Count > 0)
                {
                    reponse.Data = UserDTOs;
                    reponse.Success = true;
                    reponse.Message = $"Have {UserDTOs.Count} account.";
                    reponse.Error = "Not error";
                    return reponse;
                }
                else
                {
                    reponse.Success = false;
                    reponse.Message = $"Have {UserDTOs.Count} account.";
                    reponse.Error = "Not have a order";
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
