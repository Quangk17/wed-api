using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CheckingStaff : BaseEntity
    {
        public bool? status { get; set; }
        public int? customerID { get; set; }
        public int? staffID { get; set; }
        public int? checkingAt { get; set; }
        public int? bookingDetailID { get; set; }

        public virtual User User { get; set; }
        public virtual BookingDetail BookingDetail { get; set; }

    }
}
