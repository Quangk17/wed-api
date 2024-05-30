using Domain.Entites;
using Infrastructures.FluentAPIs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CheckingStaff> CheckingStaffs { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new CheckingStaffConfiguration());
            modelBuilder.ApplyConfiguration(new BookingDetailConfiguration());
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
