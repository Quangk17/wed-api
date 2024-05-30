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
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .HasOne(x => x.Court)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.courtID);
            builder
                 .HasOne(x => x.BookingDetail)
                .WithOne(x => x.Schedule);
            builder
                .HasOne(x => x.Slot)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.slotID);
        }
    }
}
