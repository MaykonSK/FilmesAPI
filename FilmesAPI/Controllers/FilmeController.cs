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
        public ActionResult<Filme> Filme() //ActionResult retorna uma lista + status
        {
            try
            {
                //no padrão REST, não precisa informar notfound para uma lista geral
                return Ok(_service.RecuperarFilmes());
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
        public ActionResult<bool> Filme([FromRoute] int id)
        {
            var filme = _service.RemoverFilme(id);
            if (filme == false)
            {
                return NotFound(filme);
            }

            return Ok(filme);
        }

        [HttpPut("{id}")]
        public ActionResult<Filme> Filme([FromRoute] int id, [FromBody] Filme filme)
        {
            return Ok(_service.AtualizarFilme(id, filme));
        }
    }
}
