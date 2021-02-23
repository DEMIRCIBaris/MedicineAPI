using MedicalInformationService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.DataAccess.Concrete.Mapping
{
    public class MedicineMap : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.HasOne(i => i.Storage).WithMany(i => i.Medicines).HasForeignKey(i => i.StorageId);
        }
    }
}
