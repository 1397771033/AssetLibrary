using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models.Entities
{
    public class Tenant: Entity
    {
        private Tenant()
        {

        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Tenant(string userName,string password)
        {
            GenerateId();
            UserName = userName;
            Password = password;
        }
    }
}
