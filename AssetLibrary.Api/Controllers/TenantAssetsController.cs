using AssetLibrary.Api.Infrastructure;
using AssetLibrary.Api.Models;
using AssetLibrary.Api.Models.Params.tenantAssets;
using AssetLibrary.Api.Models.VO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class TenantAssetsController: BaseController
    {
        private readonly AssetLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public TenantAssetsController(AssetLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        /// <summary>
        /// 获取租户资产下子资产数据
        /// </summary>
        /// <param name="id">资产id</param>
        /// <param name="assetType">资产类型，如果资产id为空的话会根据类型查</param>
        /// <returns></returns>
        [HttpGet]
        [Route("tenantAssets/childAssets")]
        public IActionResult GetChildAssets(string id,AssetTypeEnum assetType=AssetTypeEnum.Model)
        {
            IQueryable<TenantAsset> assets;
            // 如果资产id为空 则根据资产类型筛选
            if (string.IsNullOrWhiteSpace(id))
            {
                assets= _dbContext.TenantAssets.Where(_ => _.AssetType == assetType);
            }
            else
            {
                assets = _dbContext.TenantAssets.Where(_ => _.ParentId == id);
            }
            var result = _mapper.Map<IEnumerable<TenantAssetVO>>(assets);
            return Ok(result);
        }
        /// <summary>
        /// 添加租户资产
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("tenantAssets")]
        public IActionResult Add(AddTenantAssetParam param)
        {
            return Ok();
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="id">资产id</param>
        /// <param name="param">body参数</param>
        /// <returns></returns>
        [HttpPut]
        [Route("tenantAssets/{id}/rename")]
        public IActionResult Rename(string id, TenantAssetRenameParam param)
        {
            return Ok();
        }
        /// <summary>
        /// 移动租户资产
        /// </summary>
        /// <param name="id">资产id</param>
        /// <param name="param">body参数</param>
        /// <returns></returns>
        [HttpPut]
        [Route("tenantAssets/{id}/move")]
        public IActionResult Move(string id, TenantAssetMoveParam param)
        {
            return Ok();
        }

        /// <summary>
        /// 删除租户资产
        /// </summary>
        /// <param name="id">资产id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("tenantAssets/{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
