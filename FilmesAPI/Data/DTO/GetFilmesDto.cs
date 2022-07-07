using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO
{
    //DTO serve para modelar o dado que recebe, ou seja, não precisa de todos os atributos do Model. Como por exemplo o ID.
    public class GetFilmesDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int Ano_Lancamento { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
