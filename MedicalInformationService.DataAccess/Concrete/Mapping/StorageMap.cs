using MedicalInformationService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.DataAccess.Concrete.Mapping
{
    public class StorageMap : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.HasMany(i => i.Medicines).WithOne(i => i.Storage).HasForeignKey(i => i.StorageId);
        }
    }
}