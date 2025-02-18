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
    public class RegistrationPeriodsConfig : IEntityTypeConfiguration<RegistrationPeriods>
    {
        public void Configure(EntityTypeBuilder<RegistrationPeriods> builder)
        {
            builder.ToTable("RegistrationPeriods");
            builder.HasKey(k => k.RegistrationPeriodID);
            builder.HasOne(a => a.Facility)
                            .WithMany(p => p.Regions)
                            .HasForeignKey(a => a.User_Training_Facility_Code)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
