using FilmesAPI.Data;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        DBContext _context;
        public SessaoService(DBContext context)
        {
            _context = context;
        }

        public bool Adicionar(Sessao sessao)
        {
            bool status = false;

            if (sessao != null)
            {
                _context.Sessao.Add(sessao);
                _context.SaveChanges();
                status = true;
            }
            return status;
        }

        public IEnumerable<Sessao> Recuperar()
        {
            return _context.Sessao;
        }

        public Sessao RecuperarPorId(int id)
        {
            Sessao sessao = _context.Sessao.FirstOrDefault(x => x.Id == id);

            if (sessao != null)
            {
                return sessao;
            }

            return null;
        }
    }
}
