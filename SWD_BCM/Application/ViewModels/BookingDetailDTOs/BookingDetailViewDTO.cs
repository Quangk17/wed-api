﻿using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.BookingDetailDTOs
{
    public class BookingDetailViewDTO
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public float? amountHour { get; set; }
        public int? bookingID { get; set; }
        public int? scheduleID { get; set; }

        public virtual Schedule? Schedule { get; set; }
        public virtual CheckingStaff? CheckingStaff { get; set; }
        public virtual Booking? Booking { get; set; }
    }
}
