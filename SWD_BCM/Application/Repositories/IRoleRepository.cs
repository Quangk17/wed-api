using Application.Repositorys;
using Domain.Entites;


namespace Application.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<List<Role>> GetRolesAsync();
    }
}
