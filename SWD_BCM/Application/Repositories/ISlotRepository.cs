using Application.Repositorys;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ISlotRepository: IGenericRepository<Slot>
    {
        Task<IEnumerable<Slot>> GetSlotsAsync();
    }
}
