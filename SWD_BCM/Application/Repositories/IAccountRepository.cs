using Application.Repositorys;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Application.Repositories
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAndPasswordHash(string email, string passwordHash);

        Task<User> CheckEmailNameExisted(string email);
        Task<bool> CheckPhoneNumberExisted(string phonenumber);

        Task<User> GetUserByConfirmationToken(string token);
        Task<IEnumerable<User>> SearchAccountByNameAsync(string name);
        Task<IEnumerable<User>> GetAccountsAsync();
        Task<IEnumerable<User>> SearchAccountByRoleNameAsync(string roleName);
        Task<IEnumerable<User>> GetSortedAccountAsync();
        Task<Role> GetRoleNameByRoleId(int RoleId);



    }
}
