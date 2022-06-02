using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KefalosApi.Models;
using KefalosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KefalosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //injecting authenticate service
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            var user = _authenticateService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or Password is incorrect"});

            return Ok(user); 
        }
    }
}
