using Microsoft.AspNetCore.Mvc;

namespace AssetLibrary.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public string TenantId
        {
            get
            {
                return this.User.FindFirst("TenantId")?.Value
                    ?? throw new System.ArgumentNullException("tenantId");
            }
        }
    }
}
