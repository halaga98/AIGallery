using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SaledImageConfiguration : IEntityTypeConfiguration<SaledImage>
{
    public void Configure(EntityTypeBuilder<SaledImage> builder)
    {
        builder.ToTable("SaledImages").HasKey(si => si.Id);

        builder.Property(si => si.Id).HasColumnName("Id").IsRequired();
        builder.Property(si => si.UserId).HasColumnName("UserId");
        builder.Property(si => si.ImageId).HasColumnName("ImageId");
        builder.Property(si => si.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(si => si.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(si => si.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(si => si.User);
        builder.HasOne(si => si.Image);
        builder.HasQueryFilter(si => !si.DeletedDate.HasValue);
    }
}