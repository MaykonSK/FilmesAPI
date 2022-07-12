using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO.Gerente;
using FilmesAPI.Models;
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
    public class GerenteController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public GerenteController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Gerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getGerenteId), new { id = gerente.Id }, gerente);

        }

        [HttpGet("{id}")]
        public IActionResult getGerenteId([FromRoute] int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);
            if (gerente != null)
            {
                GetGerenteDto gerenteDto = _mapper.Map<GetGerenteDto>(gerente);
                return Ok(gerenteDto);
            }

            return NotFound();
            
        }

        [HttpDelete("{id}")]
        public void deleteGerente([FromRoute] int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(x => x.Id == id);

            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
            }
           
        }
    }
}
