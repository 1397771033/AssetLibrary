using AssetLibrary.Api.Models;
using AssetLibrary.Api.Models.Params.sceneAssets;
using AssetLibrary.Api.Models.Params.tenantAssets;
using AssetLibrary.Api.Models.VO.sceneAssets;
using AssetLibrary.Api.Models.VO.scenes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class SceneAssetsController:BaseController
    {
        /// <summary>
        /// 复制场景资产保存到租户资产
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
        /// <param name="id">资产id</param>
        /// <param name="assetType">资产类型，如果资产id为空的话根据资产类型查询</param>
        /// <returns></returns>
        [HttpGet]
        [Route("sceneAssets/childAssets")]
        [ProducesResponseType(typeof(SceneAssetsVO), (int)HttpStatusCode.OK)]
        public IActionResult GetChildAssets(string id, AssetTypeEnum assetType = AssetTypeEnum.Model)
        {
            return Ok();
        }
        /// <summary>
        /// 添加场景资产
        /// </summary>
        [HttpPost]
        [Route("sceneAssets")]
        public IActionResult Add(AddSceneAssetsParam param)
        {
            // 如果父id为空的时候，把数据添加到一级菜单下（图标/模型）
            if (string.IsNullOrWhiteSpace(param.ParentId))
            {

            }
            else
            {

            }
            return Ok();
        }
        /// <summary>
        /// 复制场景资产
        /// </summary>
        /// <param name="id">资产id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("sceneAssets/{id}/copy")]
        public IActionResult Copy(string id)
        {
            return Ok();
        }
        /// <summary>
        /// 场景资产重命名
        /// </summary>
        /// <param name="id">资产id</param>
        /// <returns></returns>
        [HttpPut]
        [Route("sceneAssets/{id}/rename")]
        public IActionResult Rename(string id,TenantAssetMoveParam param)
        {
            return Ok();
        }
    }
}
