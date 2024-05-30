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
    public class BookingTypeConfiguration : IEntityTypeConfiguration<BookingType>
    {
        public void Configure(EntityTypeBuilder<BookingType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .HasMany(x => x.Bookings)
                .WithOne(x => x.BookingType);
        }
    }
}
