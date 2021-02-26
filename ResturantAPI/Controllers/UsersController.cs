using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models;
using ResturantAPI.Models.BE;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "common")]
    public class UsersController : ControllerBase
    {
        private I_Users<Users> _repository;


        public UsersController(I_Users<Users> repository)
        {
            _repository = repository;
        }

        // POST api/<controller>
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("loginDTO is Null");
            }
            return Ok(_repository.Login(loginDTO));
        }

        // POST api/<controller>
        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterDTO registerDTO)
        {
            if (registerDTO == null)
            {
                return BadRequest("registerDTO is Null");
            }
            return Ok(_repository.Register(registerDTO));
        }

        [HttpGet("Gets"), Authorize]
        public IActionResult Gets()
        {
            return Ok(_repository.Gets());
        }
    }
}
