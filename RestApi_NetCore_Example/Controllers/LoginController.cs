using Microsoft.AspNetCore.Mvc;
using Entities.DTO;
using Microsoft.Extensions.Configuration;
using BLL.Servicios.JWT;

namespace RestApi_NetCore_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtAuthentication _auth;

        public LoginController(IConfiguration configuration, IJwtAuthentication auth)
        {
            _configuration = configuration;
            _auth = auth;
        }

        [HttpPost]
        [Route("Login")]
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
