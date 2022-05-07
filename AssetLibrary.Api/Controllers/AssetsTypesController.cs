using AssetLibrary.Api.Helpers;
using AssetLibrary.Api.Infrastructure;
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
    public class AssetsTypesController: ControllerBase
    {
        private readonly AssetLibraryDbContext _dbContext;

        public AssetsTypesController(AssetLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 获取资产类型数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("assetTypes")]
        public IActionResult GetAssetTypes()
        {
            var result = new List<object>();
            foreach (AssetTypeEnum value in Enum.GetValues(typeof(AssetTypeEnum)))
            {
                result.Add(new { key = (int)value, value = value.ToString(), display=value.GetDescription() });
            }
            return Ok(result);
        }
    }
}
