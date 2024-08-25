using eLibrary.Commons.DTOs.Requests.FajloviKnjige;
using eLibrary.Commons.Interfaces;
using eLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FajloviKnjigeController : ControllerBase
    {
        IFajloviKnjigeService _service;
        public FajloviKnjigeController(IFajloviKnjigeService service)
        {
            _service = service;
        }

        [HttpPost("CreateFajloviKnjige")]
        [Authorize(Policy = "UserOnly")]
        public async Task<IActionResult> CreateFajloviKnjige([FromForm] CreateFajloviKnjigeRequest request)
        {
            var response = await _service.CreateFajloviKnjige(request);
            if (response.Message == "Fajl uspješno uploadovan.")
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("DownloadFile")]
        [Authorize]
        public async Task<IActionResult> DownloadFile([FromQuery] GetKnjigaFileRequest request)
        {
            var filePath = await _service.GetFilePathForKnjigaAsync(request);

            if (filePath == null || !System.IO.File.Exists(filePath))
            {
                return NotFound(new { Message = "Fajl nije pronadjen ili ne posjedujete odabranu knjigu." });
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/pdf", Path.GetFileName(filePath));
        }
    }
}
