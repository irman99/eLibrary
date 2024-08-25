using eLibrary.Commons.DTOs.Requests.Zanr;
using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eLibrary.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class ZanrController : ControllerBase
        {
            private readonly IZanrService _service;

            public ZanrController(IZanrService service)
            {
                _service = service;
            }
            [Authorize]
            [HttpGet]
            [Route("GetZanrovi")]
            public IActionResult GetZanrovi()
            {
                try
                {
                    var response = _service.GetZanrovi();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [Authorize]
            [HttpGet]
            [Route("GetZanrKnjige")]
            public IActionResult GetZanrKnjige([FromQuery] GetZanrRequest request)
            {
                try
                {
                    var response = _service.GetZanrKnjige(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [Authorize(Policy = "AdminOnly")]
            [HttpPost]
            [Route("CreateZanr")]
            public IActionResult CreateZanr([FromBody] CreateZanrRequest request)
            {
                try
                {
                    var response = _service.CreateZanr(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [Authorize(Policy = "AdminOnly")]
            [HttpPut]
            [Route("UpdateZanr")]
            public IActionResult UpdateZanr([FromBody] UpdateZanrRequest request)
            {
                try
                {
                    var response = _service.UpdateZanr(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            [Authorize(Policy = "AdminOnly")]
            [HttpDelete]
            [Route("DeleteZanr")]
            public IActionResult DeleteZanr([FromBody] CommonDeleteRequest request)
            {
                try
                {
                    var response = _service.DeleteZanr(request);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
