using AssetLibrary.Api.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models
{
    /// <summary>
    /// 创建信息
    /// </summary>
    public class CreationInfo:ValueObject
    {
        private CreationInfo()
        {

        }
        public string CreatorId { get;private set; }
        public DateTime CreationTime { get; private set; }
        public CreationInfo(string creatorId,DateTime creationTime)
        {
            CreationTime = creationTime;
            CreatorId = creatorId;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CreatorId;
            yield return CreationTime;
        }
    }
}
