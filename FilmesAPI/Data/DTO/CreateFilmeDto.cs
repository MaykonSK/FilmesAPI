using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO
{
    public class CreateFilmeDto
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int Ano_Lancamento { get; set; }
    }
}
