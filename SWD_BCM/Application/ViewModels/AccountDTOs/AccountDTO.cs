using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.AccountDTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime? hours { get; set; }
        public string roleName { get; set; }
        public string? gender { get; set; }
        public int? totalDateWallet { get; set; }
        public string? ConfirmationToken { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
