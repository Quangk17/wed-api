using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Invoice : BaseEntity
    {
        public string? Type { get; set; }
        public DateTime? Time { get; set; }
        public int? bookingID { get; set; }
        public virtual Booking Booking { get; set; }

    }
}
