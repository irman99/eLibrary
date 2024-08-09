using eLibrary.Commons.DTOs.Requests.Korisnik;
using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class KorisnikController : ControllerBase
        {
            private readonly IKorisnikService _service;

            public KorisnikController(IKorisnikService service)
            {
                _service = service;
            }

            [HttpPost]
            [Route("RegisterKorisnik")]
            public IActionResult RegisterKorisnik([FromBody] RegisterKorisnikRequest request)
            {
                try
                {
                    var response = _service.RegisterKorisnik(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost]
            [Route("LoginKorisnik")]
            public IActionResult LoginKorisnik([FromBody] LoginKorisnikRequest request)
            {
                try
                {
                    var response = _service.LoginKorisnik(request);
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
