using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        //cria uma lista de filme
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        public bool AdicionarFilme(Filme filme)
        {
            bool status = false;
            bool existe = false;

            if (filme != null)
            {
                foreach (Filme item in filmes)
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
                    filme.Id = id++;
                    filmes.Add(filme);

                    status = true;
                }

            }
            return status;
        }

        public List<Filme> RecuperarFilmes()
        {
            return filmes; 
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
            return filmes.FirstOrDefault(x => x.Id == id);
        }
    }
}
