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
    public class ArticlesConfig : IEntityTypeConfiguration<Articles>
    {
        public void Configure(EntityTypeBuilder<Articles> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(k => k.ArticleID);
            builder.HasOne(a => a.Categories)
                            .WithMany(p => p.Articles)
                            .HasForeignKey(a => a.CategoryID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.WritingPhases)
                            .WithMany(p => p.Articles)
                            .HasForeignKey(a => a.WritingPhaseID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.Property(a => a.Royalty).HasPrecision(18, 4);
        }
    }
}
