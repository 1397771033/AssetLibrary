using AssetLibrary.Domain.Aggregetes.SystemAssetAggregate;
using AssetLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetLibrary.Domain.Aggregetes.TenantAssetAggregate
{
    public class TenantAsset:Entity,IAggregateRoot
    {
        private TenantAsset()
        {

        }
        /// <summary>
        /// 资产名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 资产类型
        /// </summary>
        public AssetTypeEnum AssetType { get; private set; }
        /// <summary>
        /// 上一级资产Id
        /// </summary>
        public string ParentId { get; private set; }
        /// <summary>
        /// 所属租户Id
        /// </summary>
        public string TenantId { get; private set; }
        /// <summary>
        /// 创建图标
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static TenantAsset CreateIcon(string name, string data, string parentId = null)
        {
            var tenantAsset = new TenantAsset();
            tenantAsset.GenerateId();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            tenantAsset.Name = name;
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));
            tenantAsset.Data = data;
            tenantAsset.AssetType = AssetTypeEnum.Icon;
            tenantAsset.ParentId = parentId;
            return tenantAsset;
        }
        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static TenantAsset CreateModel(string name, string data, string parentId = null)
        {
            var tenantAsset = new TenantAsset();
            tenantAsset.GenerateId();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            tenantAsset.Name = name;
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));
            tenantAsset.Data = data;
            tenantAsset.AssetType = AssetTypeEnum.Model;
            tenantAsset.ParentId = parentId;
            return tenantAsset;
        }
    }
}
