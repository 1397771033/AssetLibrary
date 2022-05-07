using AssetLibrary.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models.Entities
{
    public abstract class Entity
    {
        public string Id { get;private set; }
        /// <summary>
        /// 为该实体Id生成一个Guid并赋值，guid生成是按时间排序的，可提高性能
        /// </summary>
        public void GenerateId() => Id = GuidHelper.GeneraterByTime().ToString();
    }
}
