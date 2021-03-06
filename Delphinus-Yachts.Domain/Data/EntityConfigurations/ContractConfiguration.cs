﻿using System.Data.Entity.ModelConfiguration;
using Delphinus_Yachts.Domain.Data.Entities;

namespace Delphinus_Yachts.Domain.Data.EntityConfigurations
{
    public class ContractConfiguration : EntityTypeConfiguration<Contract>
    {
        public ContractConfiguration()
        {
            Ignore(x => x.Type);
            Property(x => x.TypeAsString)
                .HasColumnName("Type");
        }
    }
}
