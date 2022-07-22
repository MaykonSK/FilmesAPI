using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Models.DTO;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        UsuarioService _service;
        public CadastroController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult cadastrarUsuario(CreateUsuarioDto createDto)
        {
            return Ok(_service.cadastrarUsuario(createDto));
        }
    }
}
