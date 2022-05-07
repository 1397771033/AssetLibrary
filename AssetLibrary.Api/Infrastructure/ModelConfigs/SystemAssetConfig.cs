using AssetLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetLibrary.Api.Infrastructure.ModelConfigs
{
    public class SystemAssetConfig : IEntityTypeConfiguration<SystemAsset>
    {
        public void Configure(EntityTypeBuilder<SystemAsset> builder)
        {
            builder.ToTable("systemAsset");

            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .HasColumnName("id")
                .HasMaxLength(36)
                .IsRequired();
            builder.Property(_ => _.AssetType)
                .HasColumnName("assetType");
            builder.Property(_ => _.Data)
                .HasColumnName("data");
            builder.Property(_ => _.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(_ => _.ParentId)
                .HasColumnName("parentId")
                .HasMaxLength(36);
            builder.Property(_ => _.FileType)
                .HasColumnName("fileType")
                .IsRequired();
        }
    }
}
