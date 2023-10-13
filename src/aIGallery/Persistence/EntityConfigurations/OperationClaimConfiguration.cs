using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region ArtStyles
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ArtStyles.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ArtStyles.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ArtStyles.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "ArtStyles.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ArtStyles.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ArtStyles.Delete" });
        
        #endregion
        
        
        #region Categories
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        
        #endregion
        
        
        #region Images
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Images.Delete" });
        
        #endregion
        
        
        #region Likes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Likes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Likes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Likes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Likes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Likes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Likes.Delete" });
        
        #endregion
        
        
        #region SaledImages
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SaledImages.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SaledImages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SaledImages.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SaledImages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SaledImages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SaledImages.Delete" });
        
        #endregion
        
        return seeds;
    }
}
