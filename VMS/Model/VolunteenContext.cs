using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VMS.Models;

namespace VMS.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Opportunity> Opportunities { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");

                entity.HasIndex(e => e.OpportunityId, "IX_Application_OpportunityId");

                entity.HasIndex(e => e.VolunteerId, "IX_Application_VolunteerId");

                entity.Property(e => e.IsVirtual)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Opportunity)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.OpportunityId);
                    

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.VolunteerId);
            });

           

            modelBuilder.Entity<Opportunity>(entity =>
            {
                entity.ToTable("Opportunity");

                entity.HasIndex(e => e.CreateUserId, "IX_Opportunity_CreateUserId");

                entity.HasIndex(e => e.VolunteerId, "IX_Opportunity_VolunteerId");

                entity.Property(e => e.ArchivedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.ArchivedStatus)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.EndDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.EndTime).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.GroupActivity)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.OnGoing)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.StartDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.StartTime).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Virtual)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => (ICollection<Opportunity>)p.Opportunities)
                    .HasForeignKey(d => d.CreateUserId);

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.Opportunities)
                    .HasForeignKey(d => d.VolunteerId);
                
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.HasIndex(e => e.CreateUserId, "IX_Post_CreateUserId");

                entity.Property(e => e.DatePosted).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.HasOne(d => d.CreateUser)
                    .WithMany(p => p.Posts as ICollection<Post>)
                    .HasForeignKey(d => d.CreateUserId);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.ToTable("Volunteer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
