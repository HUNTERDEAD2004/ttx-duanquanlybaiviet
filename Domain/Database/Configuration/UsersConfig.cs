using AppDomain.Object;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AppDbContext.Configuration
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.UserID);
            builder.HasOne(a => a.Facility)
                            .WithMany(p => p.Users)
                            .HasForeignKey(a => a.User_Training_Facility_Code)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
