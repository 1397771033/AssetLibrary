using AssetLibrary.Api.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models
{
    /// <summary>
    /// 修改信息
    /// </summary>
    public class ModificationInfo : ValueObject
    {
        public string ModifierId { get; private set; }
        public DateTime ModificationTime { get; private set; }
        public ModificationInfo(string modifierId, DateTime modificationTime)
        {
            ModifierId = modifierId;
            ModificationTime = modificationTime;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ModifierId;
            yield return ModificationTime;
        }
    }
}
