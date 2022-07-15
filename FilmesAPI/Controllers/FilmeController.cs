using FilmesAPI.Data.DTO;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController] //define a classe como controller
    [Route("[controller]")] //vai referenciar esse controlador local
    public class FilmeController : ControllerBase //define a classe como controller
    {
        private readonly FilmeService _service;

        public FilmeController(FilmeService service) //chama o serviço no construtor
        {
            _service = service; //atribui o serviço na variavel _service 
        }

        [HttpGet]
        public ActionResult<Filme> Filme([FromQuery] string genero) //ActionResult retorna uma lista + status //FromQuery coloca um parametro na URL. (ex: https://localhost:5001/filme?Genero=Aventura)
        {
            try
            {
                //no padrão REST, não precisa informar notfound para uma lista geral
                return Ok(_service.RecuperarFilmes(genero));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Filme([FromBody] CreateFilmeDto filme)  //definindo o tipo do dado a receber
        {
            try
            {
                return Ok(_service.AdicionarFilme(filme));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Filme([FromRoute] int id) //IActionResult não precisa informar o objeto de retorno
        {
            try
            {
                var filme = _service.RecuperarFilmeId(id);
                if (filme == null)
                {
                    return NotFound();
                }

                return Ok(filme);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> RemoverFilme([FromRoute] int id)
        {
            bool filme = _service.RemoverFilme(id);
            if (filme == false)
            {
                return NotFound(filme);
            }

            return Ok(filme);
        }

        [HttpPut("{id}")]
        public ActionResult<Filme> Filme([FromRoute] int id, [FromBody] CreateFilmeDto filme)
        {
            return Ok(_service.AtualizarFilme(id, filme));
        }
    }
}
