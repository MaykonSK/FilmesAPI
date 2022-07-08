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
    public class EnderecoController : ControllerBase
    {
        EnderecoService _service;
        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Endereco([FromBody] Endereco endereco)
        {
            return Ok(_service.adicionarEndereco(endereco));
        }

        [HttpGet]
        public IActionResult Endereco()
        {
            return Ok(_service.getEnderecos());
        }

        [HttpPut("{id}")]
        public IActionResult Endereco(int id, [FromBody] Endereco endereco)
        {
            return Ok(_service.atualizarEndereco(id, endereco));
        }

        [HttpDelete]
        public ActionResult<bool> RemoverTodosEnderecos()
        {
            return Ok(_service.RemoverTodos());
        }
    }
}
