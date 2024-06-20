using Application.Repositorys;
using Domain.Entites;


namespace Application.Repositories
{
    public interface IStoreRepository: IGenericRepository<Store>
    {
        Task<List<Store>> GetStoresAsync();
    }
}
