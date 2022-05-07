﻿// <auto-generated />
using System;
using AssetLibrary.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetLibrary.Api.Migrations
{
    [DbContext(typeof(AssetLibraryDbContext))]
    partial class AssetLibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssetLibrary.Api.Models.Entities.Scene", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("scene");
                });

            modelBuilder.Entity("AssetLibrary.Api.Models.Entities.SceneAsset", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("id");

                    b.Property<int?>("AssetType")
                        .HasColumnType("int")
                        .HasColumnName("assetType");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("data");

                    b.Property<int>("FileType")
                        .HasColumnType("int")
                        .HasColumnName("fileType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("ParentId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("parentId");

                    b.Property<string>("SceneId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("sceneId");

                    b.HasKey("Id");

                    b.ToTable("sceneAsset");
                });

            modelBuilder.Entity("AssetLibrary.Api.Models.Entities.Tenant", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.ToTable("tenant");

                    b.HasData(
                        new
                        {
                            Id = "ae8e0107-88ad-442f-a7dd-964104d07e6e",
                            Password = "123456",
                            UserName = "admin1"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-44fa-b797-b762ce2a3320",
                            Password = "123456",
                            UserName = "admin2"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-4260-ad26-338cadf25f7b",
                            Password = "123456",
                            UserName = "admin3"
                        });
                });

            modelBuilder.Entity("AssetLibrary.Api.Models.SystemAsset", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("id");

                    b.Property<int?>("AssetType")
                        .HasColumnType("int")
                        .HasColumnName("assetType");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("data");

                    b.Property<int>("FileType")
                        .HasColumnType("int")
                        .HasColumnName("fileType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("ParentId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("parentId");

                    b.HasKey("Id");

                    b.ToTable("systemAsset");

                    b.HasData(
                        new
                        {
                            Id = "ae8e0107-88ad-4d41-a399-dfbe8d27fe60",
                            AssetType = 2,
                            FileType = 2,
                            Name = "建筑"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-470e-94a8-cb2b7badc560",
                            AssetType = 2,
                            Data = "住宅数据",
                            FileType = 2,
                            Name = "住宅",
                            ParentId = "ae8e0107-88ad-4d41-a399-dfbe8d27fe60"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-4abc-9e1c-a63d7bea745d",
                            AssetType = 2,
                            Data = "商业数据",
                            FileType = 2,
                            Name = "商业",
                            ParentId = "ae8e0107-88ad-4d41-a399-dfbe8d27fe60"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-4d09-98ff-8983529c0ecc",
                            AssetType = 2,
                            FileType = 2,
                            Name = "交通"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-43bf-b6b5-b2a03cebc1c4",
                            AssetType = 2,
                            Data = "信号灯数据",
                            FileType = 2,
                            Name = "信号灯",
                            ParentId = "ae8e0107-88ad-4d09-98ff-8983529c0ecc"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-44c7-976e-350c083266eb",
                            AssetType = 2,
                            Data = "公交站数据",
                            FileType = 2,
                            Name = "公交站",
                            ParentId = "ae8e0107-88ad-4d09-98ff-8983529c0ecc"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-47a9-8cdf-c50671189dc4",
                            AssetType = 2,
                            FileType = 2,
                            Name = "市政"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-4350-85d7-3c4f6bf68cb1",
                            AssetType = 2,
                            Data = "井盖数据",
                            FileType = 2,
                            Name = "井盖",
                            ParentId = "ae8e0107-88ad-47a9-8cdf-c50671189dc4"
                        },
                        new
                        {
                            Id = "ae8e0107-88ad-490b-b044-7e557d851e5a",
                            AssetType = 2,
                            Data = "售货机数据",
                            FileType = 2,
                            Name = "售货机",
                            ParentId = "ae8e0107-88ad-47a9-8cdf-c50671189dc4"
                        });
                });

            modelBuilder.Entity("AssetLibrary.Api.Models.TenantAsset", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("id");

                    b.Property<int?>("AssetType")
                        .HasColumnType("int")
                        .HasColumnName("assetType");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("data");

                    b.Property<int>("FileType")
                        .HasColumnType("int")
                        .HasColumnName("fileType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("ParentId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("parentId");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("tenantId");

                    b.HasKey("Id");

                    b.ToTable("tenantAsset");
                });

            modelBuilder.Entity("AssetLibrary.Api.Models.Entities.Scene", b =>
                {
                    b.OwnsOne("AssetLibrary.Api.Models.CreationInfo", "CreationInfo", b1 =>
                        {
                            b1.Property<string>("SceneId")
                                .HasColumnType("nvarchar(36)");

                            b1.Property<DateTime>("CreationTime")
                                .HasColumnType("datetime2")
                                .HasColumnName("creationTime");

                            b1.Property<string>("CreatorId")
                                .HasMaxLength(36)
                                .HasColumnType("nvarchar(36)")
                                .HasColumnName("creatorId");

                            b1.HasKey("SceneId");

                            b1.ToTable("scene");

                            b1.WithOwner()
                                .HasForeignKey("SceneId");
                        });

                    b.OwnsOne("AssetLibrary.Api.Models.ModificationInfo", "ModificationInfo", b1 =>
                        {
                            b1.Property<string>("SceneId")
                                .HasColumnType("nvarchar(36)");

                            b1.Property<DateTime>("ModificationTime")
                                .HasColumnType("datetime2")
                                .HasColumnName("modificationTime");

                            b1.Property<string>("ModifierId")
                                .HasMaxLength(36)
                                .HasColumnType("nvarchar(36)")
                                .HasColumnName("modifierId");

                            b1.HasKey("SceneId");

                            b1.ToTable("scene");

                            b1.WithOwner()
                                .HasForeignKey("SceneId");
                        });

                    b.Navigation("CreationInfo");

                    b.Navigation("ModificationInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
