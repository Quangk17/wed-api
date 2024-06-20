using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.CourtDTOs
{
    public class CourtDTO
    {
        public string? Name { get; set; }
        public int? StoreID { get; set; }
        public int? SlotID { get; set; }
        public bool? Status { get; set; }
    }
}
