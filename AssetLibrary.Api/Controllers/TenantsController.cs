using AssetLibrary.Api.Authorizations;
using AssetLibrary.Api.Infrastructure;
using AssetLibrary.Api.Models.Params.accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;

namespace AssetLibrary.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class TenantsController : BaseController
    {
        private readonly AssetLibraryDbContext _dbContext;

        public TenantsController(AssetLibraryDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("accounts/sign-in")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenDto), (int)HttpStatusCode.OK)]
        public IActionResult SignIn(SignInParam param)
        {
            var tenant = _dbContext.Tenants.FirstOrDefault(_ => _.UserName == param.UserName
            && _.Password == param.Password);
            if (tenant != null)
            {
                return Ok(TokenHandler.GeneratorToken(tenant.Id));
            }
            return Unauthorized();
        }
        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <returns></returns>
        [Route("accounts/refresh-token")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenDto), (int)HttpStatusCode.OK)]
        public IActionResult RefreshToken(RefreshTokenParam param)
        {
            var tokenInfo = TokenHandler.RefreshToken(param.refresh_token);
            if (tokenInfo == default)
                return Unauthorized();
            return Ok(tokenInfo);
        }
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [Route("myinfo")]
        [HttpGet]
        public IActionResult GetMyInfo()
        {
            var tenantId = this.TenantId;
            var tenant = this._dbContext.Tenants.FirstOrDefault(_ => _.Id == tenantId)
                ??throw new ArgumentNullException(nameof(tenantId));
            return Ok(new
            {
                id = tenantId,
                userName = tenant.UserName
            });
        }
    }
}
