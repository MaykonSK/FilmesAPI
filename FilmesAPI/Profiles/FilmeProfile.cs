using FilmesAPI.Data.DTO;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.Profiles
{
    //precisa criar o Profile para começar mapear
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            //precisa sempre especificar os tipos de conversão possivel
            CreateMap<CreateFilmeDto, Filme>(); //CreateFilmeDto p/ Filme
            CreateMap<Filme, GetFilmesDto>(); //Filme p/ GetFilmesDto
        }
    }
}
