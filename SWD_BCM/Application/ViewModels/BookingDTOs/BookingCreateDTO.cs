using Application.ViewModels.BookingDetailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.BookingDTOs
{
    public class BookingCreateDTO
    {
        public string? BookingName { get; set; }
        public string? Decription { get; set; }
        public DateTime? BookingDate { get; set; }
        public float? Price { get; set; }
        public int? UserID { get; set; }
        public int? BookingTypeID { get; set; }

        public virtual BookingDetailParentCreateDTO BookingDetailParentCreateDTO { get; set; }
       
    }
}
