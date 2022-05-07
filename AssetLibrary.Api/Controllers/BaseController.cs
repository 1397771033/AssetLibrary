using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Controllers
{
    public abstract class BaseController:ControllerBase
    {
        /// <summary>
        /// 后边改成从token获取
        /// </summary>
        public string UserId => Guid.NewGuid().ToString();
    }
}
