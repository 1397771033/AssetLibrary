using AssetLibrary.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetLibrary.Domain.Aggregetes.SystemAssetAggregate
{
    public class SystemAsset : Entity,IAggregateRoot
    {
        private SystemAsset()
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
        /// 创建图标
        /// </summary>
        /// <param name="name"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static SystemAsset CreateIcon(string name,string data, string parentId = null)
        {
            var systemAsset = new SystemAsset();
            systemAsset.GenerateId();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            systemAsset.Name = name;
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));
            systemAsset.AssetType = AssetTypeEnum.Icon;
            systemAsset.ParentId = parentId;
            return systemAsset;
        }
        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="name"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static SystemAsset CreateModel(string name,string data,string parentId=null)
        {
            var systemAsset = new SystemAsset();
            systemAsset.GenerateId();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            systemAsset.Name = name;
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));
            systemAsset.Data = data;
            systemAsset.AssetType = AssetTypeEnum.Model;
            systemAsset.ParentId = parentId;
            return systemAsset;
        }
    }
}
