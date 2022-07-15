using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        CinemaService _service;

        public CinemaController(CinemaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cinema([FromBody] Cinema cinema)
        {
            return Ok(_service.adicionarCinema(cinema));
        }

        [HttpGet]
        public IActionResult Cinema([FromQuery] string nomeDoFilme)
        {
            
            return Ok(_service.getCinemas(nomeDoFilme));
        }

        [HttpGet("{id}")]
        public IActionResult Cinema([FromRoute] int id)
        {
            return Ok(_service.getCinemaId(id));
        }

        [HttpPut("{id}")]
        public IActionResult Cinema(int id, [FromBody] Cinema cinema)
        {
            return Ok(_service.atualizarCinema(id, cinema));
        }

        [HttpDelete]
        public ActionResult<bool> RemoverCinema()
        {
            return Ok(_service.RemoverTodos());
        }

    }
}
