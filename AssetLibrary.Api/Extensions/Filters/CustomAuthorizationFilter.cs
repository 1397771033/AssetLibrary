using AssetLibrary.Api.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace AssetLibrary.Api.Extensions.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            
            try
            {
                var endpoint = context.HttpContext.Features.Get<IEndpointFeature>()?.Endpoint
                    ??throw new System.ArgumentNullException("endpoint");
                var actionAttribute= endpoint.Metadata.GetMetadata<AllowAnonymousAttribute>();
                if (actionAttribute == null)
                {
                    var accesstoken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("XY ", "");
                    var tokenInfo = TokenHandler.GetAccessTokenInfo(accesstoken);
                    if (tokenInfo != null)
                    {
                        var claim = new Claim("TenantId", tokenInfo.sub);
                        var claimsIdentity = new ClaimsIdentity();
                        claimsIdentity.AddClaim(claim);
                        context.HttpContext.User.AddIdentity(claimsIdentity);
                    }
                    else
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            catch (System.Exception)
            {
                context.Result=new UnauthorizedResult();
            }
        }
    }
}
