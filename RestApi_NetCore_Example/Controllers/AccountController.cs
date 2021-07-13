using BLL.BLL;
using BLL.IBLL;
using Entities.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_NetCore_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBLL _accountBLL;
        public AccountController(IAccountBLL accountBLL)
        {
            _accountBLL = accountBLL;
        }

        [HttpPost]
        [Route("Account")]
        public IActionResult Account([FromBody] AccountDTO account)
        {
            if (ModelState.IsValid)
            {
                _accountBLL.Create(account);
                return Ok("OK");
            }
            else
                return BadRequest("Ocurrio un error!");
        }
    }
}
