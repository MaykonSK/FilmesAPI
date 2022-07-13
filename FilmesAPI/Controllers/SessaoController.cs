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
    public class SessaoController : ControllerBase
    {
        SessaoService _service;
        public SessaoController(SessaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Sessao([FromBody] Sessao sessao)
        {
            try
            {
                return Ok(_service.Adicionar(sessao));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Sessao()
        {
            return Ok(_service.Recuperar());
        }

        [HttpGet("{id}")]
        public ActionResult<Sessao> Sessao([FromRoute] int id)
        {
            try
            {
                Sessao sessao = _service.RecuperarPorId(id);

                if (sessao == null)
                {
                    return NotFound();
                }

                return sessao;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
