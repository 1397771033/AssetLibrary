using System.ComponentModel;

namespace AssetLibrary.Api.Models
{
    public enum FileTypeEnum
    {
        [Description("文件夹")]
        Directory=1,
        /// <summary>
        /// 元素/组件 eg:图标/模型
        /// </summary>
        [Description("元素")]
        Element=2
    }
}
