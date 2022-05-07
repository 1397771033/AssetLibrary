namespace AssetLibrary.Api.Models.VO
{
    public class SystemAssetVO
    {
        public string Id { get; set; }
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
        /// 文件类型
        /// </summary>
        public FileTypeEnum FileType { get; set; }
    }
}
