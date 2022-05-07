using AssetLibrary.Api.Infrastructure;
using AssetLibrary.Api.Models;
using AssetLibrary.Api.Models.VO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Controllers
{
    /// <summary>
    /// 系统资产
    /// </summary>
    [ApiController]
    [Route("api")]
    public class SystemAssetsController : ControllerBase
    {
        private readonly AssetLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public SystemAssetsController(AssetLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext??throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper??throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// 获取该系统资产下的子资产
        /// </summary>
        /// <param name="id">系统资产id，如果为空则查一级目录</param>
        /// <returns></returns>
        [HttpGet]
        [Route("systemAssets/childAssets")]
        public IActionResult GetChildAssets(string id)
        {
            // 如果id为空的话，查该系统资产的一级目录
            IQueryable<SystemAsset> assets;
            if (string.IsNullOrWhiteSpace(id))
            {
                 assets = _dbContext.SystemAssets.Where(_ => _.ParentId == null);
            }
            else
            {
                 assets = _dbContext.SystemAssets.Where(_ => _.ParentId == id);
            }
            var result = _mapper.Map<IEnumerable<SystemAssetVO>>(assets);
            return Ok(result);
        }
    }
}
