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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.roleID);
            builder
                 .HasMany(x => x.Store)
                .WithOne(x => x.User);
            builder
                .HasMany(x => x.Bookings)
                .WithOne(x => x.User);
            builder
                .HasMany(x => x.CheckingStaffs)
                .WithOne(x => x.User);
            builder
                .HasOne(x => x.Wallet)
                .WithOne(x => x.User);
        }
    }
}
