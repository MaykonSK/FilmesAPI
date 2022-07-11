using AutoMapper;
using FilmesAPI.Data.DTO.Gerente;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<Gerente, GetGerenteDto>();
            CreateMap<GetGerenteDto, Gerente>();
            CreateMap<Gerente, CreateGerenteDto>();
            CreateMap<CreateGerenteDto, Gerente>();
        }
    }
}
