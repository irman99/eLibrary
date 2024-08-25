using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Komentar;
using eLibrary.Commons.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace eLibrary.Controllers;

[ApiController]
[Route("[controller]")]
public class KomentarController : ControllerBase
{
    private readonly IKomentarService _service;

    public KomentarController(IKomentarService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("GetKomentariByKnjigaId")]
    [Authorize]
    public IActionResult GetKomentariByKnjigaId([FromQuery]GetKomentariRequest request)
    {
        try
        {
            var komentari = _service.GetKomentariByKnjigaId(request);
            return Ok(komentari);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("CreateKomentar")]
    [Authorize(Policy = "UserOnly")]
    public IActionResult CreateKomentar([FromBody] CreateKomentarRequest request)
    {
        try
        {
            var response = _service.CreateKomentar(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("UpdateKomentar")]
    [Authorize(Policy = "UserOnly")]
    public IActionResult UpdateKomentar([FromBody] UpdateKomentarRequest request)
    {
        try
        {
            var response = _service.UpdateKomentar(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("DeleteKomentar")]
    [Authorize(Policy = "UserOnly")]
    public IActionResult DeleteKomentar([FromBody]CommonDeleteRequest request)
    {
        try
        {
            var response = _service.DeleteKomentar(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
