using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetLibrary.Domain.Aggregetes.SystemAssetAggregate
{
    public enum AssetTypeEnum
    {
        [Description("模型")]
        Model=1,
        [Description("图标")]
        Icon=2
    }
}
