using MedicalInformationService.DataAccess.Concrete.Mapping;
using MedicalInformationService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.DataAccess.Concrete.Context
{
    public class MyDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Database=MedicalDb;Server=(localdb)\MSSQLLocalDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicineMap());
            modelBuilder.ApplyConfiguration(new StorageMap());
            modelBuilder.ApplyConfiguration(new ActiveSubstanceMap());
            modelBuilder.ApplyConfiguration(new MedicineActiveSubstanceMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ActiveSubstance> ActiveSubstances { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Entities.MedicineActiveSubstance> MedicineActiveSubstances { get; set; }
        public DbSet<Storage> Storages { get; set; }

    }
}
