using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.InvoiceDTOs
{
    public class InvoiceViewDTO
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime? Time { get; set; }
        public int? bookingID { get; set; }
        //public virtual BookingViewDTO{get}
    }
}
