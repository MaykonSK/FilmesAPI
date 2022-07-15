using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        DBContext _context;
        private readonly IMapper _mapper;

        public CinemaService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool adicionarCinema(Cinema cinema)
        {
            bool status = false;

            if (cinema != null)
            {
                _context.Add(cinema);
                _context.SaveChanges();
                return true;
            }

            return status;  
        }

        public IEnumerable<Cinema> getCinemas(string nomeDoFilme)
        {
            IEnumerable<Cinema> cinemas = _context.Cinemas.ToList();

            if (!string.IsNullOrEmpty(nomeDoFilme)) //se nomeDoFilme for diferente de null
            {
                //Consultando via query
                IEnumerable<Cinema> query = from cinema in cinemas
                        where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                        select cinema;

                cinemas = query.ToList();
            }
            
            return cinemas;
        }

        public Cinema getCinemaId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            return cinema;
        }

        public Cinema atualizarCinema(int id, Cinema cinemaNovo)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id); //pega o primeiro que encontrar com o id fornecido ou retorna null

            //atualiza os dados - cinemaNovo p/ cinema
            _mapper.Map(cinemaNovo, cinema);
            _context.SaveChanges();

            return cinema;
        }

        public bool RemoverTodos()
        {
            IEnumerable<Cinema> cinemas = _context.Cinemas;
            _context.Cinemas.RemoveRange(cinemas);
            _context.SaveChanges();
            return true;
        }
    }
}
