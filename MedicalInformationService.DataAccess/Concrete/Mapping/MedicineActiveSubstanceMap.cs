using MedicalInformationService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.DataAccess.Concrete.Mapping
{
    public class MedicineActiveSubstanceMap : IEntityTypeConfiguration<MedicineActiveSubstance>
    {
        public void Configure(EntityTypeBuilder<MedicineActiveSubstance> builder)
        {
            builder.HasKey(mac => new { mac.ActiveSubstanceId, mac.MedicineId });
            builder.HasOne(bc => bc.ActiveSubstance).WithMany(b=>b.MedicineActiveSubstances).HasForeignKey(bc=>bc.ActiveSubstanceId);
            builder.HasOne(bc => bc.Medicine).WithMany(b => b.MedicineActiveSubstances).HasForeignKey(bc => bc.MedicineId);
        }
    }
}
