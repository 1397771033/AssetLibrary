using AssetLibrary.Api.Infrastructure.ModelConfigs;
using AssetLibrary.Api.Models;
using AssetLibrary.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetLibrary.Api.Infrastructure
{
    public class AssetLibraryDbContext : DbContext
    {
        public AssetLibraryDbContext(DbContextOptions<AssetLibraryDbContext> options
            )
            : base(options)
        {
        }
        public virtual DbSet<SystemAsset> SystemAssets { get; set; }
        public virtual DbSet<TenantAsset> TenantAssets { get; set; }
        public virtual DbSet<SceneAsset> SceneAssets { get; set; }
        public virtual DbSet<Scene> Scenes { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SystemAssetConfig());
            modelBuilder.ApplyConfiguration(new TenantAssetConfig());
            modelBuilder.ApplyConfiguration(new SceneAssetConfig());
            modelBuilder.ApplyConfiguration(new SceneConfig());
            modelBuilder.ApplyConfiguration(new TenantConfig());

            #region 种子数据
            InitSystemAssetData(modelBuilder);
            InitTenantSceneData(modelBuilder);
            #endregion

        }
        private void InitSystemAssetData(ModelBuilder modelBuilder)
        {
            var systemAsset_1 = SystemAsset.CreateIcon("建筑", null, null);
            var systemAsset_1_1 = SystemAsset.CreateIcon("住宅", "住宅数据", systemAsset_1.Id);
            var systemAsset_1_2 = SystemAsset.CreateIcon("商业", "商业数据", systemAsset_1.Id);
            var systemAsset_2 = SystemAsset.CreateIcon("交通", null, null);
            var systemAsset_2_1 = SystemAsset.CreateIcon("信号灯", "信号灯数据", systemAsset_2.Id);
            var systemAsset_2_2 = SystemAsset.CreateIcon("公交站", "公交站数据", systemAsset_2.Id);

            var systemAsset_3 = SystemAsset.CreateIcon("市政", null, null);
            var systemAsset_3_1 = SystemAsset.CreateIcon("井盖", "井盖数据", systemAsset_3.Id);
            var systemAsset_3_2 = SystemAsset.CreateIcon("售货机", "售货机数据", systemAsset_3.Id);

            modelBuilder.Entity<SystemAsset>().HasData(systemAsset_1, systemAsset_1_1, systemAsset_1_2,
                systemAsset_2, systemAsset_2_1, systemAsset_2_2,
                systemAsset_3, systemAsset_3_1, systemAsset_3_2);               
        }
        private void InitTenantSceneData(ModelBuilder modelBuilder)
        {
            var tenant_1 = new Tenant("admin1","123456");
            var tenant_2 = new Tenant("admin2", "123456");
            var tenant_3 = new Tenant("admin3", "123456");
            modelBuilder.Entity<Tenant>().HasData(tenant_1, tenant_2, tenant_3);
            //var scene_1 = Scene.Create("场景1", tenant_1.Id);
            //var scene_2 = Scene.Create("场景2", tenant_1.Id);
            //var scene_3 = Scene.Create("场景3", tenant_2.Id);
            //modelBuilder.Entity<Scene>().HasData(scene_1, scene_2, scene_3);
        }
    }
}
