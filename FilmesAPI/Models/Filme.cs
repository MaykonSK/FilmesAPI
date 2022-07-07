using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        //[Required(ErrorMessage = "ID obrigatório")] //id é necessario
        public int Id { get; set; }
        [Required(ErrorMessage = "Título obrigatório")] //titulo é necessário
        public string Titulo { get; set; }
        [StringLength(30, ErrorMessage = "Caracteres maximo é 30")] //caracteres maximo
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 e no máximo 600 minutos")] //define tempo maximo
        public int Duracao { get; set; }
        public int Ano_Lancamento { get; set; }
    }
}
