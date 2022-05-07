using AssetLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Infrastructure.ModelConfigs
{
    public class TenantAssetConfig : IEntityTypeConfiguration<TenantAsset>
    {
        public void Configure(EntityTypeBuilder<TenantAsset> builder)
        {
            builder.ToTable("tenantAsset");

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
            builder.Property(_ => _.TenantId)
                .HasColumnName("tenantId")
                .HasMaxLength(36)
                .IsRequired();
        }
    }
}
