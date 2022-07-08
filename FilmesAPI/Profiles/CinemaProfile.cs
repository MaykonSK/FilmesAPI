using AutoMapper;
using FilmesAPI.Data.DTO;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, Cinema>(); //Cinema p/ Cinema
            CreateMap<Cinema, GetCinemaDto>(); //Cinema p/ GetCinemaDto
            CreateMap<GetCinemaDto, Cinema>(); //GetCinemaDto p/ Cinema
        }
    }
}
