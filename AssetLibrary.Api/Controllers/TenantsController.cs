using AssetLibrary.Api.Infrastructure;
using AssetLibrary.Api.Models.Params.accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class TenantsController:BaseController
    {
        private readonly AssetLibraryDbContext _dbContext;

        public TenantsController(AssetLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 租户登录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("accounts/signIn")]
        [HttpPost]
        public IActionResult SignIn(SignInParam param)
        {
            bool hasTenant = _dbContext.Tenants.Any(_ => _.UserName == param.UserName 
            && _.Password == param.Password);
            if (hasTenant)
            {
                return Ok("success");
            }
            return Unauthorized();
        }
    }
}
