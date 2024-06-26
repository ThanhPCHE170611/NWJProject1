using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace NWJProject1.Models
{
    public partial class NSJProject1Context : DbContext
    {
        public NSJProject1Context()
        {
        }

        public NSJProject1Context(DbContextOptions<NSJProject1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__GroupId__267ABA7A");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__UserGrou__149AF36A070F1FD9");

                entity.ToTable("UserGroup");

                entity.Property(e => e.GroupDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
