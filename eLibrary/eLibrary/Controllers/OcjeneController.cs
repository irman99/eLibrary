using eLibrary.Commons.DTOs.Requests.Ocjene;
using eLibrary.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcjeneController : ControllerBase
    {
        private readonly IOcjeneService _service;

        public OcjeneController(IOcjeneService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateOcjenaKorisnik")]
        public IActionResult CreateOcjenaKorisnik([FromBody] CreateOcjenaRequest request)
        {
            try
            {
                var response = _service.CreateOcjenaKorisnik(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateOcjenaKnjiga")]
        public IActionResult CreateOcjenaKnjiga([FromBody] CreateOcjenaRequest request)
        {
            try
            {
                var response = _service.CreateOcjenaKnjiga(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateOcjena")]
        public IActionResult UpdateOcjena([FromBody] UpdateOcjenaRequest request)
        {
            try
            {
                var response = _service.UpdateOcjena(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetOcjenaKorisnika")]
        public IActionResult GetOcjenaKorisnika([FromQuery] GetOcjenaRequest request)
        {
            try
            {
                var response = _service.GetOcjenaKorisnika(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetOcjenaKnjige")]
        public IActionResult GetOcjenaKnjige([FromQuery] GetOcjenaRequest request)
        {
            try
            {
                var response = _service.GetOcjenaKnjige(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
