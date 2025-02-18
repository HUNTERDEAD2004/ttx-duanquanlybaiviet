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
    public class ApprovalHistoryConfig : IEntityTypeConfiguration<ApprovalHistory>
    {
        public void Configure(EntityTypeBuilder<ApprovalHistory> builder)
        {
            builder.ToTable("ApprovalHistory");
            builder.HasKey(k => k.ApprovalID);
            builder.HasOne(a => a.Articles)
                           .WithMany(p => p.Approvals)
                           .HasForeignKey(a => a.ArticleID)
                           .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Users)
                            .WithMany(p => p.ApprovalHistory)
                            .HasForeignKey(a => a.UserID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
