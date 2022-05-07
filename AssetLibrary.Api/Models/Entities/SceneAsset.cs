using System;

namespace AssetLibrary.Api.Models.Entities
{
    public class SceneAsset:Entity
    {
        private SceneAsset()
        {

        }
        /// <summary>
        /// 所属场景id
        /// </summary>
        public string SceneId { get; set; }
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
        /// 创建图标
        /// </summary>
        /// <returns></returns>
        public static SceneAsset CreateIcon(string SceneId, string name, string data, string parentId = null)
        {
            var asset = new SceneAsset();
            asset.AssetType = AssetTypeEnum.Icon;
            asset.FileType = FileTypeEnum.Element;
            asset.GenerateId();

            asset.Name = name;
            asset.ParentId = parentId;
            asset.Data = data;
            asset.SceneId = SceneId;
            return asset;
        }
        /// <summary>
        /// 创建模型
        /// </summary>
        /// <returns></returns>
        public static SceneAsset CreateModel(string SceneId, string name, string data, string parentId = null)
        {
            var asset = new SceneAsset();
            asset.AssetType = AssetTypeEnum.Model;
            asset.FileType = FileTypeEnum.Element;
            asset.GenerateId();

            asset.Name = name;
            asset.ParentId = parentId;
            asset.SceneId = SceneId;
            asset.Data = data;
            return asset;
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <returns></returns>
        public static SceneAsset CreateDirectory(string SceneId, string name, string parentId = null)
        {
            var asset = new SceneAsset();
            asset.FileType = FileTypeEnum.Directory;
            asset.GenerateId();

            asset.Name = name;
            asset.SceneId = SceneId;
            asset.ParentId = parentId;
            return asset;
        }
    }
}
