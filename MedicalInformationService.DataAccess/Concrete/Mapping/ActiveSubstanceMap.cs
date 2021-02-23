using MedicalInformationService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInformationService.DataAccess.Concrete.Mapping
{
    public class ActiveSubstanceMap : IEntityTypeConfiguration<ActiveSubstance>
    {
        public void Configure(EntityTypeBuilder<ActiveSubstance> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
        }
    }
}
