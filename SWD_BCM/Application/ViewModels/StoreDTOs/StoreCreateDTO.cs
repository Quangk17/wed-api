using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.StoreDTOs
{
    public class StoreCreateDTO
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public bool? status { get; set; }
        public DateTime? timeActive { get; set; }
        public bool IsDeleted { get; set; }
        public int userId { get; set; }

    }
}
