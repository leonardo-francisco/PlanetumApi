using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanetumAuthenticationMicroservice.Configuration;
using PlanetumDomain.Entities;

namespace PlanetumAuthenticationMicroservice.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] User user)
        {
            string token = null;
            if (user.Username == "planetum" && user.Password == "planetum")
            {
                token = TokenConfiguration.GenerateToken(user.Username);
                return Ok(new
                {
                    user = user.Username,
                    token = token
                });
            }
            else
            {
                return NotFound("User or password incorrect");
            }
                       
        }
    }
}
