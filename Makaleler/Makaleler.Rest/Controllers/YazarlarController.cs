using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Makaleler.Business.Abstract;
using Makaleler.Entities.Concrete;
using Makaleler.Rest.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Makaleler.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarlarController : ControllerBase
    {

        private readonly IYazarService _service;
        private readonly IConfiguration _configuration;

        public YazarlarController(IYazarService service,
            IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }


        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var list = _service.GetAll();
            if (list.Count()>0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpPost]
        [Route("kayit")]
        public IActionResult Register([FromBody]UserForRegisterDto yazar)
        {
            if (_service.UserExists(yazar.UserName))
            {
                ModelState.AddModelError(nameof(yazar.UserName), "Kullanıcı Adı Mevcut");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createUser = new Yazar
            {
                Username = yazar.UserName,
                Name=yazar.Name,
                LastName=yazar.LastName
            };

            try
            {
                _service.Register(createUser, yazar.Password);
                return StatusCode(201);
            }
            catch 
            {

                return BadRequest();
            }
         

        }



        [HttpPost("login")]
        public ActionResult Login([FromBody] UserForLoginDto userForLoginDto)
        {
            var user = _service.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.YazarId.ToString()),
                    new Claim(ClaimTypes.Name,user.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
        }

    }
}