using AppDomain.Object;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Database.AppDbContext
{
    public class QuanLyBaiVietDbcontext : DbContext
    {
        public QuanLyBaiVietDbcontext()
        {
            
        }

        public QuanLyBaiVietDbcontext(DbContextOptions options) : base(options)
        {
        }

        #region Dbset
        public virtual DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        public virtual DbSet<Hashtag> Hashtags { get; set; }
        public virtual DbSet<User_RegistrationPeriods> User_RegistrationPeriods { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WritingPhases> WritingPhases { get; set; }
        public virtual DbSet<RegistrationPeriods> RegistrationPeriods { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Articles_Hashtag> Articles_Hashtags { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Database HoangAnh
                //optionsBuilder.UseSqlServer("Server=DESKTOPD-DELLIN\\SQLEXPRESS;Database=DuAnWebThuVienOnline;Trusted_Connection=True;TrustServerCertificate=True");

                //Database Dung
                //optionsBuilder.UseSqlServer();

                //Database Loc
                optionsBuilder.UseSqlServer("Server=DESKTOP-67I2820\\SQLEXPRESS01;Database=TTSQuanlybaiviet;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
