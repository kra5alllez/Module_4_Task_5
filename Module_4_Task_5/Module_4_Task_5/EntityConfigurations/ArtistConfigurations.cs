using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Module_4_Task_5
{
    public class ArtistConfigurations : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("ArtistId");
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            builder.Property(p => p.DateOfBirth).IsRequired().HasColumnName("DateOfBirth").HasColumnType("date");
            builder.Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(13);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(100);
            builder.Property(p => p.InstagramUrl).HasColumnName("InstagramUrl").HasMaxLength(300);


            builder.HasMany(c => c.Songs)
                .WithMany(s => s.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "SongArtist",
                    j => j
                        .HasOne<Song>()
                        .WithMany()
                        .HasForeignKey("ArtistId"),
                    j => j
                        .HasOne<Artist>()
                        .WithMany()
                        .HasForeignKey("SongId"));
        }
    }
}
