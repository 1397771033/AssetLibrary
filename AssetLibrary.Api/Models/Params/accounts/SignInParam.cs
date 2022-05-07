using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models.Params.accounts
{
    public class SignInParam
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
