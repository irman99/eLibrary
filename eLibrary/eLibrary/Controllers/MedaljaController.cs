﻿using eLibrary.Commons.DTOs.Requests;
using eLibrary.Commons.DTOs.Requests.Medalja;
using eLibrary.Commons.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedaljaController : ControllerBase
    {
        private readonly IMedaljaService _service;

        public MedaljaController(IMedaljaService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateMedalja")]
        public IActionResult CreateMedalja([FromBody] CreateMedaljaRequest request)
        {
            try
            {
                var response = _service.CreateMedalja(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllMedalje")]
        public IActionResult GetAllMedalje()
        {
            try
            {
                var medalje = _service.GetAllMedalje();
                return Ok(medalje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateMedalja")]
        public IActionResult UpdateMedalja([FromBody] UpdateMedaljaRequest request)
        {
            try
            {
                var response = _service.UpdateMedalja(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteMedalja")]
        public IActionResult DeleteMedalja([FromBody]CommonDeleteRequest request)
        {
            try
            {
                var response = _service.DeleteMedalja(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AssignMedaljaToKorisnik")]
        public IActionResult AssignMedaljaToKorisnik([FromBody] AssignMedaljaToKorisnikRequest request)
        {
            try
            {
                var response = _service.AssignMedaljaToKorisnik(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetMedaljeForKorisnik")]
        public IActionResult GetMedaljeForKorisnik([FromQuery] GetMedaljeForKorisnikRequest request)
        {
            try
            {
                var medalje = _service.GetMedaljeForKorisnik(request);
                return Ok(medalje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}