using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
<<<<<<< HEAD
        public IRoleRepository RoleRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public ICourtRepository CourtRepository { get; }

        public IScheduleRepository ScheduleRepository { get; }
        public ISlotRepository SlotRepository { get; }

=======
        public IBookingRepository BookingRepository { get; }
        public IBookingTypeRepository BookingTypeRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IBookingDetailRepository BookingDetailRepository { get; }
>>>>>>> d1d00f5fbf5b12f9ea15223702e3ebf0824a8210
        public Task<int> SaveChangeAsync();
    }
}
