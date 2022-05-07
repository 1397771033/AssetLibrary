using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models.Params.scenes
{
    public class SceneVO
    {
        public int Total { get; set; }
        public IEnumerable<SceneItemVO> Scenes { get; set; }
    }
    public class SceneItemVO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
