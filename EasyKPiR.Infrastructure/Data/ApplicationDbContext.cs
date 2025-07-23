using EasyKPiR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyKPiR.Infrastructure.Data
    {
    public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }


        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Contractor> Contractors { get; set; } = default!;
        public DbSet<KpirEntry> KpirEntries { get; set; } = default!;
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; } = default!;
        public DbSet<SalesInvoice> SalesInvoices { get; set; } = default!;
        public DbSet<FixedAsset> FixedAssets { get; set; } = default!;
        public DbSet<MinimumWage> MinimumWages { get; set; } = default!;
        public DbSet<ZusRate> ZusRates { get; set; } = default!;
        public DbSet<ZusDeclaration> ZusDeclarations { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MinimumWage>().HasData(
            new MinimumWage { Id = 1, Year = 2025, Minimum = 4666m, Average = 7500m }
        );

            modelBuilder.Entity<ZusRate>().HasData(
                new ZusRate { Id = 1, Year = 2025, RateName = "Pension", RateValue = 0.1952m },
                new ZusRate { Id = 2, Year = 2025, RateName = "Disability", RateValue = 0.08m },
                new ZusRate { Id = 3, Year = 2025, RateName = "Accident", RateValue = 0.0167m },
                new ZusRate { Id = 4, Year = 2025, RateName = "Sickness", RateValue = 0.0245m },
                new ZusRate { Id = 5, Year = 2025, RateName = "LaborFund", RateValue = 0.0245m },
                new ZusRate { Id = 6, Year = 2025, RateName = "Health", RateValue = 0.09m },
                new ZusRate { Id = 7, Year = 2025, RateName = "HealthOverThreshold", RateValue = 0.049m }
            );

            }
        }
    }
