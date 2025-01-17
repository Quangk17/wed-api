﻿using Application.Repositories;
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

        public IRoleRepository RoleRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public ICourtRepository CourtRepository { get; }

        public IScheduleRepository ScheduleRepository { get; }
        public ISlotRepository SlotRepository { get; }


        public IBookingRepository BookingRepository { get; }
        public IBookingTypeRepository BookingTypeRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IBookingDetailRepository BookingDetailRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
