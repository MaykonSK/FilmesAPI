using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        //cria uma lista de filme
        private static List<Filme> filmes = new List<Filme>();

        public bool adicionarFilme(Filme filme)
        {
            bool status = false;
            bool existe = false;

            if (filme != null)
            {
                foreach (var item in filmes)
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
                    filmes.Add(filme);

                    status = true;
                }

            }
            return status;
        }

        public List<Filme> recuperarFilmes()
        {
            return filmes; 
        }
    }
}
