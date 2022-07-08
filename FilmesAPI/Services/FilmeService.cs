using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        //conexao com o banco
        private DBContext _context;
        private readonly IMapper _mapper;

        public FilmeService(DBContext context, IMapper mapper) //construtor
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AdicionarFilme(CreateFilmeDto filmeDto)
        {
            bool status = false;

            //passar os dados do DTO para o filme
            //Filme filme = new Filme
            //{
            //    Titulo = filmeDto.Titulo,
            //    Diretor = filmeDto.Diretor,
            //    Genero = filmeDto.Genero,
            //    Duracao = filmeDto.Duracao,
            //    Ano_Lancamento = filmeDto.Ano_Lancamento,
            //};

            //utilizando auto mapper
            Filme filme = _mapper.Map<Filme>(filmeDto); //passando os dados de filmeDto para Filme
                
            if (filme != null)
            {
                 //add o filme
                _context.Filmes.Add(filme); //adiciona o filme
                _context.SaveChanges(); //informa que quer salvar
                status = true;

            }
            return status;
        }

        public IEnumerable<Filme> RecuperarFilmes()
        {
            //return _context.Filmes; //recupera todos os filmes
            IEnumerable<Filme> filme =  _context.Filmes.ToList();
            return filme;

        }

        public GetFilmesDto RecuperarFilmeId(int id)
        {     
            //recupera dado no banco
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            //Remodelando o retorno - retorna DTO
            //GetFilmesDto filmeDto = new GetFilmesDto
            //{
            //    Id = filme.Id,
            //    Titulo = filme.Titulo,
            //    Diretor = filme.Diretor,
            //    Genero = filme.Genero,
            //    Duracao = filme.Duracao,
            //    Ano_Lancamento = filme.Ano_Lancamento,
            //    HoraDaConsulta = DateTime.Now
            //};

            //mandar os dados do filme para filmeDto
            GetFilmesDto filmeDto = _mapper.Map<GetFilmesDto>(filme);

            return filmeDto;
        }
        public bool RemoverFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            var ok = false;

            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                ok = true;
            }
            return ok;
        }

        public bool AtualizarFilme(int id, CreateFilmeDto filmeAtualizar)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            bool ok = false;

            if (filme != null)
            {
                //filme.Titulo = filmeAtualizar.Titulo;
                //filme.Diretor = filmeAtualizar.Genero;
                //filme.Genero = filmeAtualizar.Genero;
                //filme.Duracao = filmeAtualizar.Duracao;
                //filme.Ano_Lancamento = filmeAtualizar.Ano_Lancamento;

                //envia os dados do filmeAtualizar para filme
                _mapper.Map(filmeAtualizar, filme);

                _context.SaveChanges();

                return ok = true;
            }

            return ok;

        }
    }
}
