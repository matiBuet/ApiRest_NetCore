using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTO;
using Microsoft.Extensions.Configuration;
using System.Text;
using BLL.Servicios;

namespace RestApi_NetCore_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtAuthentication _auth;

        public AccountsController(IConfiguration configuration, IJwtAuthentication auth)
        {
            _configuration = configuration;
            _auth = auth;
        }

        [HttpPost]
        [Route ("Login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            if (ModelState.IsValid)
            {                          
                var token = _auth.Authenticate(login.usuario, login.pass);
                if (token == null)
                    return Unauthorized();
                else
                    return Ok(token);
            }
            else
                return BadRequest("Ocurrio un error!");
        }
    }
}
