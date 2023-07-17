using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings
{
    public class LibraryMap : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
           builder.ToTable("Library");

           builder.HasKey(x => x.Id); 

           builder.Property(x => x.Id)
                    .UseIdentityColumn()
                    .HasColumnType("BIGINT");

            builder.Property(x => x.NameBook)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nameBk")
                    .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.CodeSerial)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("codeSerial")
                    .HasColumnType("BIGINT");

            builder.Property(x => x.BkExists)
                    .IsRequired()
                    .HasMaxLength(180)
                    .HasColumnName("bkExists")
                    .HasColumnType("BIT");                       
        }
    }
}