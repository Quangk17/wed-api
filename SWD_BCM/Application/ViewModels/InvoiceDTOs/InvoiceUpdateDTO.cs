using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.InvoiceDTOs
{
    public class InvoiceUpdateDTO
    {
        public string? Type { get; set; }
        public DateTime? Time { get; set; }
        public int? bookingID { get; set; }
    }
}
