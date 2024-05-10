using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    public class ChangeHistory : IEntityTypeConfiguration<ChangeHistory>
    {
        public void Configure(EntityTypeBuilder<ChangeHistory> builder)
        {
            builder.HasKey();
        }
    }
}
