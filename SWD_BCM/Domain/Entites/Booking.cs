using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Booking : BaseEntity
    {
        public string? BookingName { get; set; }
        public string? Decription { get; set; }
        public DateTime? BookingDate { get; set; }
        public bool StatusPayment { get; set; }
        public float? TotalPrice { get; set; }
        public int? UserID { get; set; }
        public int? BookingTypeID { get; set; }

        //R
        public virtual User? User { get; set; }
        public virtual IEnumerable<BookingDetail> BookingDetails { get; set; }
        public virtual BookingType BookingType { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}
