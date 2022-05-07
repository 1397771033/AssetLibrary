using AssetLibrary.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class SceneAssetsController:BaseController
    {
        /// <summary>
        /// 保存到场景资产
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("sceneAssets/{id}/saveTo-tenantAsset")]
        public IActionResult SaveToTenantAsset()
        {
            return Ok();
        }
        /// <summary>
        /// 获取场景资产下的子资产
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("sceneAssets/childAssets")]
        public IActionResult GetChildAssets(string id, AssetTypeEnum assetType = AssetTypeEnum.Model)
        {
            return Ok();
        }
        /// <summary>
        /// 添加场景资产
        /// </summary>
        [HttpPost]
        [Route("sceneAssets")]
        public IActionResult Add()
        {
            return Ok();
        }
        /// <summary>
        /// 复制场景资产
        /// </summary>
        [HttpPost]
        [Route("sceneAssets/{id}/copy")]
        public IActionResult Copy(string id)
        {
            return Ok();
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("sceneAssets/{id}/rename")]
        public IActionResult Rename(string id)
        {
            return Ok();
        }
    }
}
