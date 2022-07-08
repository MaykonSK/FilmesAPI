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
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, GetFilmesDto>();
        }
    }
}
