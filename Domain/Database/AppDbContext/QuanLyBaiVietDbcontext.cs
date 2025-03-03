using AppDomain.Object;
using Domain.Data.Entities;
using Domain.Data.Enum;
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
                //optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedingData(modelBuilder);
        }

        public void SeedingData(ModelBuilder modelBuilder)
        {
            // seed articles
            modelBuilder.Entity<Articles>().HasData(
                new Articles
                {
                    ArticleID = 1,
                    Title = "C# Code First Essentials",
                    Content = "This article covers the essentials of using Code First approach in C#...",
                    EmailFe = "author1@example.com",
                    Royalty = 15.75m,
                    Download_path = "/downloads/csharp-essentials.pdf",
                    Preview_Image = "/images/csharp-essentials.jpg",
                    Description = "A comprehensive guide to Code First in C#.",
                    CreateDate = new DateTime(2024, 2, 1),
                    ModifiedDate = new DateTime(2024, 2, 10),
                    CategoryID = 1,
                    AuthorID = 1,
                    WritingPhaseID = 2
                },
                new Articles
                {
                    ArticleID = 2,
                    Title = "Mastering SQL Server",
                    Content = "This article provides advanced techniques for optimizing SQL Server performance...",
                    EmailFe = "author2@example.com",
                    Royalty = 20.00m,
                    Download_path = "/downloads/sql-server-master.pdf",
                    Preview_Image = "/images/sql-server-master.jpg",
                    Description = "Advanced SQL Server performance optimization techniques.",
                    CreateDate = new DateTime(2024, 1, 15),
                    ModifiedDate = new DateTime(2024, 2, 5),
                    CategoryID = 2,
                    AuthorID = 2,
                    WritingPhaseID = 3
                },
                new Articles
                {
                    ArticleID = 3,
                    Title = "Entity Framework Best Practices",
                    Content = "Learn the best practices when working with Entity Framework...",
                    EmailFe = "author3@example.com",
                    Royalty = 18.50m,
                    Download_path = "/downloads/ef-best-practices.pdf",
                    Preview_Image = "/images/ef-best-practices.jpg",
                    Description = "Improve your Entity Framework skills with best practices.",
                    CreateDate = new DateTime(2024, 2, 5),
                    ModifiedDate = new DateTime(2024, 2, 12),
                    CategoryID = 1,
                    AuthorID = 3,
                    WritingPhaseID = 1
                }
            );

            modelBuilder.Entity<ApprovalHistory>().HasData(
                new ApprovalHistory
                {
                    ApprovalID = 1,
                    ArticleID = 1,
                    UserID = 101,
                    Type = "Initial Review",
                    Note = "Article needs minor revisions.",
                    CreateAt = new DateTime(2024, 2, 1),
                    CreateDate = new DateTime(2024, 2, 1),
                    ModifiledDate = new DateTime(2024, 2, 2),
                    Status = HistoryApprovalStatus.Rejected
                },
                new ApprovalHistory
                {
                    ApprovalID = 2,
                    ArticleID = 2,
                    UserID = 102,
                    Type = "Final Approval",
                    Note = "Article approved for publishing.",
                    CreateAt = new DateTime(2024, 2, 3),
                    CreateDate = new DateTime(2024, 2, 3),
                    ModifiledDate = new DateTime(2024, 2, 3),
                    Status = HistoryApprovalStatus.Approved
                }
            );

            modelBuilder.Entity<Articles_Hashtag>().HasData(
                new Articles_Hashtag
                {
                    Id = 1,
                    HashtagID = 1,
                    ArcticleID = 1,
                    CreateDate = new DateTime(2024, 2, 1),
                    ModifiedDate = new DateTime(2024, 2, 2)
                },
                new Articles_Hashtag
                {
                    Id = 2,
                    HashtagID = 2,
                    ArcticleID = 1,
                    CreateDate = new DateTime(2024, 2, 1),
                    ModifiedDate = new DateTime(2024, 2, 3)
                },
                new Articles_Hashtag
                {
                    Id = 3,
                    HashtagID = 1,
                    ArcticleID = 2,
                    CreateDate = new DateTime(2024, 2, 5),
                    ModifiedDate = new DateTime(2024, 2, 6)
                }
            );

            modelBuilder.Entity<Categories>().HasData(
                new Categories
                {
                    CategoryID = 1,
                    Name = "Programming",
                    Description = "Books and articles related to software development.",
                    Royalty = 10.5m,
                    Status = EntityStatus.Active
                },
                new Categories
                {
                    CategoryID = 2,
                    Name = "Database",
                    Description = "Resources about SQL, NoSQL, and database management.",
                    Royalty = 12.0m,
                    Status = EntityStatus.Active
                },
                new Categories
                {
                    CategoryID = 3,
                    Name = "Data Science",
                    Description = "Articles on machine learning, AI, and big data analytics.",
                    Royalty = 15.0m,
                    Status = EntityStatus.Inactive
                }
            );

            modelBuilder.Entity<Facility>().HasData(
                new Facility
                {
                    FacilityId = 1,
                    Name = "Hà nội"
                },
                new Facility
                {
                    FacilityId = 2,
                    Name = "Hồ chí minh"
                },
                new Facility
                {
                    FacilityId = 3,
                    Name = "Đà nẵng"
                },
                new Facility
                {
                    FacilityId = 4,
                    Name = "Cần thơ"
                },
                new Facility
                {
                    FacilityId = 5,
                    Name = "Hải phòng"
                }
            );

            modelBuilder.Entity<Hashtag>().HasData(
                new Hashtag
                {
                    HashtagID = 1,
                    Title = "CSharp",
                    CreateDate = new DateTime(2024, 2, 1),
                    ModifiedDate = new DateTime(2024, 2, 5)
                },
                new Hashtag
                {
                    HashtagID = 2,
                    Title = "SQLServer",
                    CreateDate = new DateTime(2024, 2, 2),
                    ModifiedDate = new DateTime(2024, 2, 6)
                },
                new Hashtag
                {
                    HashtagID = 3,
                    Title = "EntityFramework",
                    CreateDate = new DateTime(2024, 2, 3),
                    ModifiedDate = new DateTime(2024, 2, 7)
                },
                new Hashtag
                {
                    HashtagID = 4,
                    Title = "DatabaseOptimization",
                    CreateDate = new DateTime(2024, 2, 4),
                    ModifiedDate = new DateTime(2024, 2, 8)
                },
                new Hashtag
                {
                    HashtagID = 5,
                    Title = "CodeFirst",
                    CreateDate = new DateTime(2024, 2, 5),
                    ModifiedDate = new DateTime(2024, 2, 9)
                }
            );

            modelBuilder.Entity<RegistrationPeriods>().HasData(
                new RegistrationPeriods
                {
                    RegistrationPeriodID = 1,
                    Name = "Spring 2024",
                    RegistrationStart = new DateTime(2024, 3, 1),
                    RegistrationEnd = new DateTime(2024, 3, 15),
                    User_Training_Facility_Code = 101,
                    CreateAt = new DateTime(2024, 2, 1),
                    ModifiedAt = new DateTime(2024, 2, 5),
                    StartDate = new DateTime(2024, 3, 20),
                    EndDate = new DateTime(2024, 6, 30),
                    Is_Opening_registration = true
                },
                new RegistrationPeriods
                {
                    RegistrationPeriodID = 2,
                    Name = "Summer 2024",
                    RegistrationStart = new DateTime(2024, 6, 1),
                    RegistrationEnd = new DateTime(2024, 6, 15),
                    User_Training_Facility_Code = 102,
                    CreateAt = new DateTime(2024, 5, 1),
                    ModifiedAt = new DateTime(2024, 5, 5),
                    StartDate = new DateTime(2024, 6, 20),
                    EndDate = new DateTime(2024, 9, 30),
                    Is_Opening_registration = false
                },
                new RegistrationPeriods
                {
                    RegistrationPeriodID = 3,
                    Name = "Fall 2024",
                    RegistrationStart = new DateTime(2024, 9, 1),
                    RegistrationEnd = new DateTime(2024, 9, 15),
                    User_Training_Facility_Code = 103,
                    CreateAt = new DateTime(2024, 8, 1),
                    ModifiedAt = new DateTime(2024, 8, 5),
                    StartDate = new DateTime(2024, 9, 20),
                    EndDate = new DateTime(2024, 12, 15),
                    Is_Opening_registration = true
                },
                new RegistrationPeriods
                {
                    RegistrationPeriodID = 4,
                    Name = "Winter 2025",
                    RegistrationStart = new DateTime(2024, 12, 1),
                    RegistrationEnd = new DateTime(2024, 12, 15),
                    User_Training_Facility_Code = 104,
                    CreateAt = new DateTime(2024, 11, 1),
                    ModifiedAt = new DateTime(2024, 11, 5),
                    StartDate = new DateTime(2025, 1, 5),
                    EndDate = new DateTime(2025, 3, 15),
                    Is_Opening_registration = false
                },
                new RegistrationPeriods
                {
                    RegistrationPeriodID = 5,
                    Name = "Spring 2025",
                    RegistrationStart = new DateTime(2025, 3, 1),
                    RegistrationEnd = new DateTime(2025, 3, 15),
                    User_Training_Facility_Code = 105,
                    CreateAt = new DateTime(2025, 2, 1),
                    ModifiedAt = new DateTime(2025, 2, 5),
                    StartDate = new DateTime(2025, 3, 20),
                    EndDate = new DateTime(2025, 6, 30),
                    Is_Opening_registration = true
                }
            );

            modelBuilder.Entity<User_RegistrationPeriods>().HasData(
                new User_RegistrationPeriods
                {
                    ID = 1,
                    UserID = 1,
                    CategoryID = 1,
                    WritingPhaseID = 2,
                    RegistrationPeriods = 1,
                    CreateDate = new DateTime(2024, 2, 1),
                    ModifiedDate = new DateTime(2024, 2, 5)
                },
                new User_RegistrationPeriods
                {
                    ID = 2,
                    UserID = 2,
                    CategoryID = 2,
                    WritingPhaseID = 3,
                    RegistrationPeriods = 2,
                    CreateDate = new DateTime(2024, 3, 1),
                    ModifiedDate = new DateTime(2024, 3, 6)
                },
                new User_RegistrationPeriods
                {
                    ID = 3,
                    UserID = 3,
                    CategoryID = 1,
                    WritingPhaseID = 1,
                    RegistrationPeriods = 3,
                    CreateDate = new DateTime(2024, 4, 1),
                    ModifiedDate = new DateTime(2024, 4, 8)
                },
                new User_RegistrationPeriods
                {
                    ID = 4,
                    UserID = 4,
                    CategoryID = 3,
                    WritingPhaseID = 2,
                    RegistrationPeriods = 4,
                    CreateDate = new DateTime(2024, 5, 1),
                    ModifiedDate = new DateTime(2024, 5, 10)
                },
                new User_RegistrationPeriods
                {
                    ID = 5,
                    UserID = 5,
                    CategoryID = 2,
                    WritingPhaseID = 3,
                    RegistrationPeriods = 5,
                    CreateDate = new DateTime(2024, 6, 1),
                    ModifiedDate = new DateTime(2024, 6, 12)
                }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserID = 1,
                    Name = "John Doe",
                    Code = "EMP001",
                    Email = "johndoe@example.com",
                    EmailFE = "johndoe.fe@example.com",
                    Avatar = "/avatars/johndoe.jpg",
                    Bio = "Senior Developer at Tech Corp.",
                    Role = RoleSetUp.Admin,
                    Createdate = new DateTime(2024, 1, 10),
                    Modifiedate = new DateTime(2024, 2, 1),
                    UStatus = EntityStatus.Active,
                    User_Training_Facility_Code = 101
                },
                new Users
                {
                    UserID = 2,
                    Name = "Jane Smith",
                    Code = "EMP002",
                    Email = "janesmith@example.com",
                    EmailFE = "janesmith.fe@example.com",
                    Avatar = "/avatars/janesmith.jpg",
                    Bio = "Database Administrator with expertise in SQL Server.",
                    Role = RoleSetUp.Admin,
                    Createdate = new DateTime(2024, 1, 15),
                    Modifiedate = new DateTime(2024, 2, 5),
                    UStatus = EntityStatus.Active,
                    User_Training_Facility_Code = 102
                },
                new Users
                {
                    UserID = 3,
                    Name = "Alice Johnson",
                    Code = "EMP003",
                    Email = "alicejohnson@example.com",
                    EmailFE = "alicejohnson.fe@example.com",
                    Avatar = "/avatars/alicejohnson.jpg",
                    Bio = "Machine Learning Engineer, specializing in AI models.",
                    Role = RoleSetUp.Teacher,
                    Createdate = new DateTime(2024, 1, 20),
                    Modifiedate = new DateTime(2024, 2, 10),
                    UStatus = EntityStatus.Active,
                    User_Training_Facility_Code = 103
                },
                new Users
                {
                    UserID = 4,
                    Name = "Bob Williams",
                    Code = "EMP004",
                    Email = "bobwilliams@example.com",
                    EmailFE = "bobwilliams.fe@example.com",
                    Avatar = "/avatars/bobwilliams.jpg",
                    Bio = "Software Architect, passionate about clean code.",
                    Role = RoleSetUp.Teacher,
                    Createdate = new DateTime(2024, 1, 25),
                    Modifiedate = new DateTime(2024, 2, 12),
                    UStatus = EntityStatus.Inactive,
                    User_Training_Facility_Code = 104
                },
                new Users
                {
                    UserID = 5,
                    Name = "Charlie Brown",
                    Code = "EMP005",
                    Email = "charliebrown@example.com",
                    EmailFE = "charliebrown.fe@example.com",
                    Avatar = "/avatars/charliebrown.jpg",
                    Bio = "Full-stack Developer working with modern web technologies.",
                    Role = RoleSetUp.Teacher,
                    Createdate = new DateTime(2024, 2, 1),
                    Modifiedate = new DateTime(2024, 2, 15),
                    UStatus = EntityStatus.Active,
                    User_Training_Facility_Code = 105
                }
            );

            modelBuilder.Entity<WritingPhases>().HasData(
                new WritingPhases
                {
                    WritingPhaseID = 1,
                    Name = "Initial Draft",
                    AmountArticles = 10,
                    StartDate = new DateTime(2024, 3, 1),
                    EndDate = new DateTime(2024, 4, 30),
                    CreateAt = new DateTime(2024, 2, 15),
                    ModifiedAt = new DateTime(2024, 2, 20),
                    Is_Opening_registration = true,
                    RegistrationPeriodID = 1
                },
                new WritingPhases
                {
                    WritingPhaseID = 2,
                    Name = "Peer Review",
                    AmountArticles = 8,
                    StartDate = new DateTime(2024, 5, 1),
                    EndDate = new DateTime(2024, 6, 30),
                    CreateAt = new DateTime(2024, 3, 15),
                    ModifiedAt = new DateTime(2024, 3, 20),
                    Is_Opening_registration = false,
                    RegistrationPeriodID = 2
                },
                new WritingPhases
                {
                    WritingPhaseID = 3,
                    Name = "Final Revision",
                    AmountArticles = 6,
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 8, 31),
                    CreateAt = new DateTime(2024, 5, 15),
                    ModifiedAt = new DateTime(2024, 5, 20),
                    Is_Opening_registration = true,
                    RegistrationPeriodID = 3
                },
                new WritingPhases
                {
                    WritingPhaseID = 4,
                    Name = "Publication Approval",
                    AmountArticles = 5,
                    StartDate = new DateTime(2024, 9, 1),
                    EndDate = new DateTime(2024, 10, 31),
                    CreateAt = new DateTime(2024, 7, 15),
                    ModifiedAt = new DateTime(2024, 7, 20),
                    Is_Opening_registration = false,
                    RegistrationPeriodID = 4
                },
                new WritingPhases
                {
                    WritingPhaseID = 5,
                    Name = "Archived",
                    AmountArticles = 12,
                    StartDate = new DateTime(2024, 11, 1),
                    EndDate = new DateTime(2025, 1, 31),
                    CreateAt = new DateTime(2024, 9, 15),
                    ModifiedAt = new DateTime(2024, 9, 20),
                    Is_Opening_registration = false,
                    RegistrationPeriodID = 5
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
