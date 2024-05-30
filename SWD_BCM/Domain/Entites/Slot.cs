using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Slot : BaseEntity
    {
        public string? name { get; set; }
        public DateTime startHours { get; set; }
        public DateTime endHours { get; set; }

        public virtual IEnumerable<Schedule> Schedules { get; set; }
    }
}
