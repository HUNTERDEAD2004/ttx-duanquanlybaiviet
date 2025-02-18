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
    public class Articles_HashtagConfig : IEntityTypeConfiguration<Articles_Hashtag>
    {
        public void Configure(EntityTypeBuilder<Articles_Hashtag> builder)
        {
            builder.ToTable("Articles_Hashtag");
            builder.HasKey(k => k.Id);
            builder.HasOne(a => a.Hashtag)
                            .WithMany(p => p.Articles_Hashtags)
                            .HasForeignKey(a => a.HashtagID)
                            .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Articles)
                            .WithMany(p => p.Articles_Hashtags)
                            .HasForeignKey(a => a.ArcticleID)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
