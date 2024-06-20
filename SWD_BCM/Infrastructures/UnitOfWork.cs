using Application;
using Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
<<<<<<< HEAD
        private readonly IRoleRepository _roleRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ICourtRepository _courtRepository;

        private readonly ISlotRepository _slotRepository;
        private readonly IScheduleRepository _scheduleRepository;


        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository, IRoleRepository roleRepository,
            IStoreRepository storeRepository, ICourtRepository courtRepository, ISlotRepository slotRepository, IScheduleRepository scheduleRepository )
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _storeRepository = storeRepository;
            _courtRepository = courtRepository;
            _slotRepository = slotRepository;
            _scheduleRepository = scheduleRepository;

=======
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingTypeRepository _bookingTypeRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IBookingDetailRepository _bookDetailRepository;
        public UnitOfWork(AppDbContext dbContext, 
            IAccountRepository accountRepository, 
            IBookingRepository bookingRepository, 
            IBookingTypeRepository bookingTypeRepository, 
            IInvoiceRepository invoiceRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _bookingRepository = bookingRepository;
            _bookingTypeRepository = bookingTypeRepository;
            _invoiceRepository = invoiceRepository;
>>>>>>> d1d00f5fbf5b12f9ea15223702e3ebf0824a8210
        }

        public IAccountRepository AccountRepository => _accountRepository;
        public IBookingRepository BookingRepository => _bookingRepository;
        public IBookingTypeRepository BookingTypeRepository => _bookingTypeRepository;
        public IInvoiceRepository InvoiceRepository => _invoiceRepository;
        public IBookingDetailRepository BookingDetailRepository => _bookDetailRepository;

        public IRoleRepository RoleRepository => _roleRepository;

        public IStoreRepository StoreRepository => _storeRepository;

        public ICourtRepository CourtRepository => _courtRepository;

        public IScheduleRepository ScheduleRepository => _scheduleRepository;
        public ISlotRepository SlotRepository => _slotRepository;


        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
