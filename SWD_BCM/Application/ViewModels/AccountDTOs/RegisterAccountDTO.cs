using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountDTOs
{
    public class RegisterAccountDTO
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phoneNumber { get; set; }
        public string? gender { get; set; }
    }
}
