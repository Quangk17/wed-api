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

        }

        public IAccountRepository AccountRepository => _accountRepository;

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
