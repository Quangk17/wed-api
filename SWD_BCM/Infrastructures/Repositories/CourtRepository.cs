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
    public class CourtRepository: GenericRepository<Court>, ICourtRepository
    {
        private readonly AppDbContext _dbContext;
        public CourtRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }


        public async Task<List<Court>> GetCourtsAsync()
        {
            var data = await _dbContext.Courts.ToListAsync();
            if (data == null || data.Count == 0)
            {
                return null;
            }
            return data;
        }
    }
}
