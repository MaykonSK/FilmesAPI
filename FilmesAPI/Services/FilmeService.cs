using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        //conexao com o banco
        private DBContext _context;

        public FilmeService(DBContext context) //construtor
        {
            _context = context;
        }

        public bool AdicionarFilme(Filme filme)
        {
            bool status = false;
            bool existe = false;

            if (filme != null)
            {
                foreach (Filme item in _context.Filmes)
                {
                    if (item.Id == filme.Id)
                    {
                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    //add o filme
                    _context.Filmes.Add(filme); //adiciona o filme
                    _context.SaveChanges(); //informa que quer salvar
                    status = true;
                }

            }
            return status;
        }

        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes; //recupera todos os filmes
        }

        public Filme RecuperarFilmeId(int id)
        {
            //metodo 1
            //foreach (Filme item in filmes)
            //{
            //    if (item.Id == id)
            //    {
            //        return item;
            //    }
            //}

            //return null;

            //metood 2
            return _context.Filmes.FirstOrDefault(x => x.Id == id);
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

        public bool AtualizarFilme(int id, Filme filmeAtualizar)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            bool ok = false;

            if (filme != null)
            {
                filme.Titulo = filmeAtualizar.Titulo;
                filme.Diretor = filmeAtualizar.Genero;
                filme.Genero = filmeAtualizar.Genero;
                filme.Duracao = filmeAtualizar.Duracao;
                filme.Ano_Lancamento = filmeAtualizar.Ano_Lancamento;

                _context.SaveChanges();

                return ok = true;
            }

            return ok;

        }
    }
}
