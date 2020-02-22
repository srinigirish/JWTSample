using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

//custom namespaces
using iDynamics.Identity.API.Services;
using iDynamics.Identity.API.Services.Intefaces;
using iDynamics.Identity.API.Models;

namespace iDynamics.Identity.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticate _authService;

        public AuthenticationController(IAuthenticate authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Login loginParam)
        {
            var token = _authService.Authenticate(loginParam.Username, loginParam.Password);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(token);
        }
    }
}