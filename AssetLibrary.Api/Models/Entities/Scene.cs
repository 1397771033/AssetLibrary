using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models.Entities
{
    public class Scene : Entity
    {
        /// <summary>
        /// 场景名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建信息
        /// </summary>
        public CreationInfo CreationInfo { get; private set; }
        /// <summary>
        /// 修改信息
        /// </summary>
        public ModificationInfo ModificationInfo { get; private set; }
        private Scene()
        {

        }
        public static Scene Create(string name, string creatorId)
        {
            var scene = new Scene();
            scene.GenerateId();
            scene.Name = name;
            scene.CreationInfo = new CreationInfo(creatorId, DateTime.Now);
            scene.ModificationInfo = new ModificationInfo(creatorId, DateTime.Now);
            return scene;
        }

        public void ModifyName(string name,string modifierId)
        {
            Name = name;
            ModificationInfo = new ModificationInfo(modifierId, DateTime.Now);
        }
    }
}
