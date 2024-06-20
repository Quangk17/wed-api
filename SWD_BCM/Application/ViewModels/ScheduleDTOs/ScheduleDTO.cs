using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ScheduleDTOs
{
    public class ScheduleDTO
    {
        public float? price { get; set; }
        public bool? status { get; set; }
        public DateTime? date { get; set; }
        public int? courtID { get; set; }
        public int? slotID { get; set; }
    }
}
