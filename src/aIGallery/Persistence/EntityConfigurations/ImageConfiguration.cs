using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(i => i.Promt).HasColumnName("Promt");
        builder.Property(i => i.ArtStyleId).HasColumnName("ArtStyleId");
        builder.Property(i => i.UserId).HasColumnName("UserId");
        builder.Property(i => i.CategoryId).HasColumnName("CategoryId");
        builder.Property(i => i.ImgToImg).HasColumnName("ImgToImg");
        builder.Property(i => i.Discover).HasColumnName("Discover");
        builder.Property(i => i.SaleStatus).HasColumnName("SaleStatus");
        builder.Property(i => i.SalePrice).HasColumnName("SalePrice");
        builder.Property(i => i.Blocked).HasColumnName("Blocked");
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(i => i.ArtStyle);
        builder.HasOne(i => i.Category);
        builder.HasOne(i => i.User);
        builder.HasMany(i => i.Like);
        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}