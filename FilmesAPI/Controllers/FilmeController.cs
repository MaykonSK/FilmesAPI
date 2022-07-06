using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController] //define a classe como controller
    [Route("[controller]")] //vai referenciar esse controlador local
    public class FilmeController : ControllerBase //define a classe como controller
    {
        FilmeService service = new FilmeService();

        [HttpGet]
        public ActionResult<Filme> Filme() //ActionResult retorna uma lista + status
        {
            try
            {
                List<Filme> filmes = service.recuperarFilmes();
                if (filmes.Count == 0)
                {
                    return NotFound();
                }

                return Ok(filmes);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Filme([FromBody] Filme filme)
        {
            try
            {
                bool status = service.adicionarFilme(filme);
                return Ok(status);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
