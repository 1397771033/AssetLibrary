namespace AssetLibrary.Api.Models.Params.tenantAssets
{
    public class AddTenantAssetParam
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
    }
}
