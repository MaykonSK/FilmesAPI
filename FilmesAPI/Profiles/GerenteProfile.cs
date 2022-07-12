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
            //Estamos mapeando de um Gerente para um ReadGerenteDto. Para o campo Cinemas, estamos selecionando apenas os campos Id, Nome, Endereco e EnderedoId.
            //mapear atributos especificos para evitar dados repetidos
            CreateMap<Gerente, GetGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opt => opt 
                .MapFrom(gerente => gerente.Cinemas.Select                   
                (c => new { c.Id, c.Nome, c.Endereco })));

            CreateMap<GetGerenteDto, Gerente>();
            CreateMap<Gerente, CreateGerenteDto>();
            CreateMap<CreateGerenteDto, Gerente>();
        }
    }
}
