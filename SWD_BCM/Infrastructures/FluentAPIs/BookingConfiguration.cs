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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.User)
                    .WithMany(pc => pc.Bookings)
                    .HasForeignKey(p => p.UserID);
            builder.HasMany(x => x.BookingDetails)
                    .WithOne(x => x.Booking);
            builder. HasOne(x => x.BookingType)
                    .WithMany(x => x.Bookings)
                    .HasForeignKey(x => x.BookingTypeID);
            builder.HasOne(x => x.Invoice)
                    .WithOne(x => x.Booking)
                    .HasForeignKey<Invoice>(x => x.bookingID);
        }
    }
}
