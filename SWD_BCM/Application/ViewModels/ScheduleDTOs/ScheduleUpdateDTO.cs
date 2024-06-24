using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ScheduleDTOs
{
    public class ScheduleUpdateDTO
    {
        public float? price { get; set; }
        public bool? status { get; set; }
        public DateTime? date { get; set; }
        public int? courtID { get; set; }
        public int? slotID { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
