using eLibrary.Commons.DTOs.Requests.Korisnik;
using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace eLibrary.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class KorisnikController : ControllerBase
        {
            private readonly IKorisnikService _service;
            private readonly UserManager<IdentityUser> _userManager;
            private readonly RoleManager<IdentityUser> _roleManager;
            private readonly IConfiguration _configuration;

            public KorisnikController(IKorisnikService service,UserManager<IdentityUser>userManager,RoleManager<IdentityUser>roleManager,IConfiguration configuration)
            {
                _service = service;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            }

        [HttpGet("Me")]
        public IActionResult GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var user = _service.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("RegisterKorisnik")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterKorisnik([FromBody] RegisterKorisnikRequest request)
        {
            try
            {
                var response = await _service.RegisterKorisnikAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("LoginKorisnik")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginKorisnik([FromBody] LoginKorisnikRequest request)
        {
            try
            {
                var response = await _service.LoginKorisnikAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
            [Route("GetKorisnik")]
            public IActionResult GetKorisnik([FromQuery] GetKorisnikRequest request)
            {
                try
                {
                    var response = _service.GetKorisnik(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut]
            [Route("UpdateKorisnik")]
            [Authorize]
            public IActionResult UpdateKorisnik([FromBody] UpdateKorisnikRequest request)
            {
                try
                {
                    var response = _service.UpdateKorisnik(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        [HttpGet]
        [Route("GetAllKorisniks")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetAllKorisniks()
        {
            try
            {
                var response = _service.GetAllKorisniks();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
            [Route("DeleteKorisnik")]
            [Authorize(Policy = "AdminOnly")]
            public IActionResult DeleteKorisnik([FromBody] CommonDeleteRequest request)
            {
                try
                {
                    var response = _service.DeleteKorisnik(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    
}
