using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClient
{
    public static class Models
    {
        public class AuthenticationSecurityToken
        {
            public string auth_token { get; set; }
        }
        public class Login
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

    }
}
