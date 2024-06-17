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
        public IBookingRepository BookingRepository { get; }
        public IBookingTypeRepository BookingTypeRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IBookingDetailRepository BookingDetailRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
