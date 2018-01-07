using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hub.Models.Dbcontext
{
    public class DomainDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<DomainUser> DomainUsers { get; set; }

        public DomainDbContext() :
            base("DomainConnection")
        {      
 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {         

            modelBuilder.Entity<Project>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.ContactEmail).IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.Title).IsRequired();
            modelBuilder.Entity<Tag>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Unit>().Property(u => u.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<University>().Property(u => u.UniName).IsRequired();
            modelBuilder.Entity<University>().Property(u => u.State).IsRequired();

            modelBuilder.Entity<DomainUser>()
                .Property(du => du.Id).HasColumnType("nvarchar").HasDatabaseGeneratedOption(null);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tag)
                .WithMany(t => t.Project)
                .Map(m =>
                {
                    m.ToTable("ProjectTags");
                    m.MapLeftKey("ProjectId");
                    m.MapRightKey("TagId");
                });

            modelBuilder.Entity<DomainUser>()
                .HasMany(u => u.Projects)
                .WithMany(p => p.DomainUser)
                .Map(m =>
                {
                    m.ToTable("UserProjects");
                    m.MapLeftKey("ProjectId");
                    m.MapRightKey("DomainUserId");
                });

            modelBuilder.Entity<DomainUser>()
                .HasMany(u => u.University)
                .WithMany(uni => uni.DomainUser)
                .Map(m =>
                {
                    m.ToTable("UniversityStudent");
                    m.MapLeftKey("UniversityId");
                    m.MapRightKey("UserId");
                });

            modelBuilder.Entity<University>()
                .HasMany(i => i.Units)
                .WithMany(v => v.Universities)
                .Map(m =>
                {
                    m.ToTable("UniversityUnits");
                    m.MapLeftKey("UniversityId");
                    m.MapRightKey("UnitId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}