using Application.Interfaces;
using Application.Repositories;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;


namespace Infrastructures.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _dbContext;
        public RoleRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var data = await _dbContext.Roles.ToListAsync();
            if (data == null || data.Count == 0)
            {
                return null;
            }
            return  data;
        }

       


    }
}
