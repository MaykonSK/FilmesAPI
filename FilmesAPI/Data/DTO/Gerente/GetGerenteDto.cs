using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTO.Gerente
{
    public class GetGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; } //um objeto de Cinemas. O mesmo deve ser configurado no CinemaProfile
    }
}
