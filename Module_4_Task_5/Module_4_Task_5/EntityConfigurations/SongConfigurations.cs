using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Module_4_Task_5
{
    public class SongConfigurations : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasColumnName("SongId");
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            builder.Property(p => p.Duration).IsRequired().HasColumnName("Duration").HasColumnType("time");
            builder.Property(p => p.ReleaseDate).IsRequired().HasColumnName("ReleaseDate").HasColumnType("date");

            builder.HasOne(d => d.Gener)
                .WithMany(p => p.Songs)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
