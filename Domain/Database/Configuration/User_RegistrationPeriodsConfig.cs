using AppDomain.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AppDbContext.Configuration
{
    public class User_RegistrationPeriodsConfig : IEntityTypeConfiguration<User_RegistrationPeriods>
    {
        public void Configure(EntityTypeBuilder<User_RegistrationPeriods> builder)
        {
            builder.ToTable("User_RegistrationPeriods");
            builder.HasKey(k => k.ID);
            builder.HasOne(a => a.Users)
                            .WithMany(p => p.User_RegistrationPeriods)
                            .HasForeignKey(a => a.UserID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Categories)
                            .WithMany(p => p.User_Registrations)
                            .HasForeignKey(a => a.CategoryID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.WritingPhases)
                            .WithMany(p => p.UserRegistrationPeriods)
                            .HasForeignKey(a => a.WritingPhaseID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
