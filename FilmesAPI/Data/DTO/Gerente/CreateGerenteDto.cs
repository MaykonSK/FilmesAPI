using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTO.Gerente
{
    public class CreateGerenteDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
