
namespace Domain.Entites
{
    public class User : BaseEntity
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime? hours { get; set; }
        public int? roleID { get; set; }
        public string? gender { get; set; }
        public int? totalDateWallet { get; set; }
        public string? ConfirmationToken { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual Role? Role { get; set; }
        public virtual IEnumerable<Store> Store { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }
        public virtual IEnumerable<CheckingStaff> CheckingStaffs { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
