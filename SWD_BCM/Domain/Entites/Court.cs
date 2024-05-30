using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Domain.Entites
{
    public class Court : BaseEntity
    {
        public string? Name { get; set; }
        public int? StoreID { get; set; }
        public int? SlotID { get; set; }
        public bool? Status { get; set; }
        public virtual Store Store { get; set; }
        public virtual IEnumerable<Schedule> Schedules { get; set; }

    }
}
