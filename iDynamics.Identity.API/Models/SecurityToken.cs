using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iDynamics.Identity.API.Models
{
    /// <summary>
    /// SecurityToken class that holds the JSON Web Token in format [header].[payload].[signature]
    /// </summary>
    public class AuthenticationSecurityToken
    {
        public string authentication_token { get; set; }
    }
}
