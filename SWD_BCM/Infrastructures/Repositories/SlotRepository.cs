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
    public class SlotRepository: GenericRepository<Slot>, ISlotRepository
    {
        private readonly AppDbContext _dbContext;
        public SlotRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Slot>> GetSlotsAsync()
        {
            return await _dbContext.Slots.ToListAsync();
        }
    }
}
