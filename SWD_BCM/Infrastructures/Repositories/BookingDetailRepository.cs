using Application.Interfaces;
using Application.Repositories;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class BookingDetailRepository : GenericRepository<BookingDetail>, IBookingDetailRepository
    {
        private readonly AppDbContext _dbContext;
        public BookingDetailRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }
    }
}
