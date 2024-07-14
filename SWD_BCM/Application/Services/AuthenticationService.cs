﻿using Application.Commons;
using Application.Interfaces;
using Application.ServiceResponses;
using Application.Utils;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.CourtDTOs;
using AutoMapper;
using Domain.Entites;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.Common;


namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenticationService(
            IUnitOfWork unitOfWork,
            ICurrentTime currentTime,
            AppConfiguration configuration,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _configuration = configuration;
            _mapper = mapper;
        }

        

        public async Task<ServiceResponse<string>> LoginAsync(AuthenAccountDTO accountDto)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var users = await _unitOfWork.AccountRepository.GetAllAsync();
                var user = users.Where(x => x.email.ToLower().Equals(accountDto.email.ToLower()) &&
                    x.password.ToLower().Equals(accountDto.password.ToLower())).FirstOrDefault();
                if (user == null)
                {
                    response.Success = false;
                    response.Message = "Invalid username or password";
                    return response;
                }

                if (user.ConfirmationToken != null && !user.IsConfirmed)
                {
                    System.Console.WriteLine(user.ConfirmationToken + user.IsConfirmed);
                    response.Success = false;
                    response.Message = "Please confirm via link in your mail";
                    return response;
                }
                var rolename = await _unitOfWork.AccountRepository.GetRoleNameByRoleId((int) user.roleID);

                var token = user.GenerateJsonWebToken(
                    _configuration,
                    _configuration.JWTSection.SecretKey,
                    _currentTime.GetCurrentTime(),
                    rolename.RoleName
                );

                response.Success = true;
                response.Message = "Login successfully.";
                response.Data = token;
            }
            catch (DbException ex)
            {
                response.Success = false;
                response.Message = "Database error occurred.";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
            }

            return response;

        }

        async Task<ServiceResponse<AccountDTO>> IAuthenticationService.RegisterAsync(RegisterAccountDTO registerAccountDTO)
        {
            var response = new ServiceResponse<AccountDTO>();
            try
            {
                var exist = await _unitOfWork.AccountRepository.CheckEmailNameExisted(registerAccountDTO.email);
                if (exist != null)
                {
                    response.Success = false;
                    response.Message = "Email is existed";
                    return response;
                }
                var user = _mapper.Map<User>(registerAccountDTO);
                // Tạo token ngẫu nhiên
                user.ConfirmationToken = Guid.NewGuid().ToString();
                
                user.roleID = 5;
                await _unitOfWork.AccountRepository.AddAsync(user);
                var confirmationLink = $"https://localhost:7017/swagger/confirm?token={user.ConfirmationToken}";

                // Gửi email xác nhận
                var emailSent = await SendEmail.SendConfirmationEmail(user.email, confirmationLink);
                if (!emailSent)
                {
                    // Xử lý khi gửi email không thành công
                    response.Success = false;
                    response.Message = "Error sending confirmation email.";
                    return response;
                }
                else
                {
                    var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (isSuccess)
                    {
                        var userDTO = _mapper.Map<AccountDTO>(user);
                        response.Data = userDTO; // Chuyển đổi sang UserDTO
                        response.Success = true;
                        response.Message = "Register successfully.";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Error saving the account.";
                    }
                }
            }
            catch (DbException ex)
            {
                response.Success = false;
                response.Message = "Database error occurred.";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.ErrorMessages = new List<string> { ex.Message };
            }
            return response;
        }
    }

}
