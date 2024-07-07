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
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        private readonly AppDbContext _dbContext;
        public ScheduleRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }

        public async Task<List<Schedule>> GetSchedulesAsync()
        {
            var data = await _dbContext.Schedules.ToListAsync();
            if (data == null || data.Count == 0)
            {
                return null;
            }
            return data;
        }
    }
}
