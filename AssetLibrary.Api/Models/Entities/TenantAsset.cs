using AssetLibrary.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models
{
    public class TenantAsset:Entity
    {
        /// <summary>
        /// 资产名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 资产类型，区分该资产是模型/图标
        /// </summary>
        public AssetTypeEnum? AssetType { get; set; }
        /// <summary>
        /// 上一级资产Id
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public FileTypeEnum FileType { get; set; }
        /// <summary>
        /// 租户id
        /// </summary>
        public string TenantId { get; set; }
        private TenantAsset()
        {

        }
        /// <summary>
        /// 创建图标
        /// </summary>
        /// <returns></returns>
        public static TenantAsset CreateIcon(string tenantId,string name, string data, string parentId = null)
        {
            var asset = new TenantAsset();
            asset.AssetType = AssetTypeEnum.Icon;
            asset.FileType = FileTypeEnum.Element;
            asset.GenerateId();

            asset.Name = name;
            asset.ParentId = parentId;
            asset.Data = data;
            asset.TenantId = tenantId;
            return asset;
        }
        /// <summary>
        /// 创建模型
        /// </summary>
        /// <returns></returns>
        public static TenantAsset CreateModel(string tenantId, string name, string data, string parentId = null)
        {
            var asset = new TenantAsset();
            asset.AssetType = AssetTypeEnum.Model;
            asset.FileType = FileTypeEnum.Element;
            asset.GenerateId();

            asset.Name = name;
            asset.ParentId = parentId;
            asset.Data = data;
            asset.TenantId = tenantId;
            return asset;
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <returns></returns>
        public static TenantAsset CreateDirectory(string tenantId, string name, string parentId = null)
        {
            var asset = new TenantAsset();
            asset.FileType = FileTypeEnum.Directory;
            asset.GenerateId();

            asset.Name = name;
            asset.ParentId = parentId;
            asset.TenantId = tenantId;
            return asset;
        }
    }
}
