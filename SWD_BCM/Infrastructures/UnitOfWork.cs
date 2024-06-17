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
        }

        public IAccountRepository AccountRepository => _accountRepository;
        public IBookingRepository BookingRepository => _bookingRepository;
        public IBookingTypeRepository BookingTypeRepository => _bookingTypeRepository;
        public IInvoiceRepository InvoiceRepository => _invoiceRepository;
        public IBookingDetailRepository BookingDetailRepository => _bookDetailRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
