﻿using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.SlotDTOs
{
    public class SlotCreateDTO
    {
        public string? name { get; set; }
        public DateTime startHours { get; set; }
        public DateTime endHours { get; set; }

    }
}
