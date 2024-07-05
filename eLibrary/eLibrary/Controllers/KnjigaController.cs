using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Knjiga;
using eLibrary.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnjigaController : ControllerBase
    {
        IKnjigaService _service;
        public KnjigaController(IKnjigaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetKnjige")]
        public IActionResult GetKnjige([FromQuery] GetKnjigeRequest request)
        {
            try
            {
                var response = _service.GetKnjige(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateKnjiga")]
        public IActionResult CreateKnjiga([FromBody] CreateKnjigaRequest request)
        {
            try
            {
                var response = _service.CreateKnjiga(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateKnjiga")]
        public IActionResult UpdateKnjiga([FromBody] UpdateKnjigaRequest request)
        {
            try
            {
                var response = _service.UpdateKnjiga(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteKnjiga")]
        public IActionResult DeleteKnjiga([FromBody] CommonDeleteRequest request)
        {
            try
            {
                var response = _service.DeleteKnjiga(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
