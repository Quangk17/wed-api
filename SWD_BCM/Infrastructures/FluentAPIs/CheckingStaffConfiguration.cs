using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPIs
{
    public class CheckingStaffConfiguration : IEntityTypeConfiguration<CheckingStaff>
    {
        public void Configure(EntityTypeBuilder<CheckingStaff> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.CheckingStaffs)
                .HasForeignKey(x => x.customerID);
            builder
                .HasOne(x => x.BookingDetail)
                .WithOne(x => x.CheckingStaff);
        }
    }
}
