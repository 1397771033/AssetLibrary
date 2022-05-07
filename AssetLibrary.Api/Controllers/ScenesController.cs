using AssetLibrary.Api.Infrastructure;
using AssetLibrary.Api.Models.VO.scenes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AssetLibrary.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ScenesController:BaseController
    {
        private readonly AssetLibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public ScenesController(AssetLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取场景数据
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="size">页大小</param>
        /// <returns></returns>
        [HttpGet]
        [Route("scenes")]
        [ProducesResponseType(typeof(SceneVO), (int)HttpStatusCode.OK)]
        public IActionResult Get(int page=1,int size =15)
        {
            var scenes = _dbContext.Scenes.Skip((page - 1) * size).Take(size);
            var result = new SceneVO
            {
                Total = _dbContext.Scenes.Count(),
                Scenes = _mapper.Map<IEnumerable<SceneItemVO>>(scenes)
            };
            return Ok(result);
        }
    }
}
