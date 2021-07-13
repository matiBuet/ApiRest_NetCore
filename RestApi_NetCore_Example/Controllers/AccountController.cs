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
        [Route("create")]
        public IActionResult Create([FromBody] AccountDTO account)
        {
            if (ModelState.IsValid)
            {
                _accountBLL.Create(account, User.Identity.Name);
                return Ok("OK");
            }
            else
                return BadRequest("Ocurrio un error!");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(long id,[FromBody] AccountDataDTO account)
        {
            if (ModelState.IsValid)
            {
                _accountBLL.Update(id, account, User.Identity.Name);
                return Ok("OK");
            }
            else
                return BadRequest("Ocurrio un error!");
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(long id)
        {
            if (ModelState.IsValid)
            {
                _accountBLL.Delete(id, User.Identity.Name);
                return Ok("OK");
            }
            else
                return BadRequest("Ocurrio un error!");
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {                
                return Ok(_accountBLL.GetAll());
            }
            else
                return BadRequest("Ocurrio un error!");
        }
    }
}
