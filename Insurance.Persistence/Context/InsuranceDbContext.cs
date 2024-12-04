using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Persistence.Context
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }

        public DbSet<Insured> Insureds { get; set; }
        public DbSet<InsurancePolicy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insured>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.PersonalNumber).HasMaxLength(11).IsRequired();
                entity.HasIndex(e => e.PersonalNumber).IsUnique();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasMany(i => i.Policies)
                    .WithOne(p => p.Insured)
                    .HasForeignKey(p => p.InsuredId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<InsurancePolicy>(entity =>
            {
                entity.Property(e => e.PolicyNumber).HasMaxLength(20).IsRequired();
                entity.HasIndex(e => e.PolicyNumber).IsUnique();
                entity.Property(e => e.Coverage).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Premium).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
