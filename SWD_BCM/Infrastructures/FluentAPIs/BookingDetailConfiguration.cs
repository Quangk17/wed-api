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
    public class BookingDetailConfiguration : IEntityTypeConfiguration<BookingDetail>
    {
        public void Configure(EntityTypeBuilder<BookingDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .HasOne(x => x.CheckingStaff)
                .WithOne(x => x.BookingDetail)
                .HasForeignKey<CheckingStaff>(x => x.bookingDetailID);
            builder
                .HasOne(x => x.Schedule)
                .WithOne(x => x.BookingDetail)
                .HasForeignKey<BookingDetail>(x => x.scheduleID);
            builder
                .HasOne(x => x.Booking)
                .WithMany(x => x.BookingDetails)
                .HasForeignKey(x => x.bookingID);
        }
    }
}
