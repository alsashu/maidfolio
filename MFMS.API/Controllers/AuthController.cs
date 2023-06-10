using MFMS.Application.Repository;
using MFMS.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MFMS.API.Controllers
{
    [Authorize]
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public ITokenRepository _tokenRepository;

        public AuthController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public List<string> Get()
        {
            var recruits = new List<string>
            {
                "John Doe",
                "Jane Doe",
                "Junior Doe"
            };
            return recruits;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Post(Users usersdata)
        {
            var token = _tokenRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        
        //[HttpGet("{contact_number}")]
        //[Route("message_service")]
        //public IActionResult Get(string contact_number)
        //{
            
        //    return Ok();
        //}
    }
}
