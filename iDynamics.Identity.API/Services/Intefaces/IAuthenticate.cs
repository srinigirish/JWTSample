using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iDynamics.Identity.API.Models;

namespace iDynamics.Identity.API.Services.Intefaces
{
    public interface IAuthenticate
    {
        AuthenticationSecurityToken Authenticate(string userName, string password);
    }
}
