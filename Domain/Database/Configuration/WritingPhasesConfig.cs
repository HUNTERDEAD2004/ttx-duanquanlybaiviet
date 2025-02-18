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
    public class WritingPhasesConfig : IEntityTypeConfiguration<WritingPhases>
    {
        public void Configure(EntityTypeBuilder<WritingPhases> builder)
        {
            builder.ToTable("WritingPhases");
            builder.HasKey(k => k.WritingPhaseID);
            builder.HasOne(a => a.RegistrationPeriods)
                            .WithMany(p => p.WritingPhases)
                            .HasForeignKey(a => a.RegistrationPeriodID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
