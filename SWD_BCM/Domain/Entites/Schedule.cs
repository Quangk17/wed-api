using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Schedule : BaseEntity
    {
        public float? price { get; set; }
        public bool? status { get; set; }
        public DateTime? date { get; set; }
        public int? courtID { get; set; }
        public int? slotID { get; set; }
        public virtual Court Court { get; set; }
        public virtual BookingDetail BookingDetail { get; set; }
        public virtual Slot Slot { get; set; }

    }
}
