using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_Task_5.EntityConfigurations
{
    class GenreConfigurations : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("GenreId");
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);   
        }
    }
}
