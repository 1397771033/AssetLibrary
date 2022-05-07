using AssetLibrary.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Infrastructure.ModelConfigs
{
    public class SceneConfig : IEntityTypeConfiguration<Scene>
    {
        public void Configure(EntityTypeBuilder<Scene> builder)
        {
            builder.ToTable("scene");

            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .HasColumnName("id")
                .HasMaxLength(36)
                .IsRequired();
            builder.OwnsOne(_ => _.CreationInfo, info =>
               {
                   info.Property(_ => _.CreatorId)
                   .HasMaxLength(36)
                   .HasColumnName("creatorId");
                   info.Property(_ => _.CreationTime)
                   .HasColumnName("creationTime");
               }
               );
            builder.OwnsOne(_ => _.ModificationInfo, info =>
               {
                   info.Property(_ => _.ModifierId)
                   .HasMaxLength(36)
                   .HasColumnName("modifierId");
                   info.Property(_ => _.ModificationTime)
                   .HasColumnName("modificationTime");
               });

            builder.Property(_ => _.Name)
                .HasColumnName("name");
        }
    }
}
