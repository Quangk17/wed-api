using Application.Interfaces;
using Application.Repositories;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly AppDbContext _dbContext;
        public StoreRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }

        public async Task<List<Store>> GetStoresAsync()
        {
            var data = await _dbContext.Stores.ToListAsync();
            if (data == null || data.Count == 0)
            {
                return null;
            }
            return data;
        }

       
    }
}
