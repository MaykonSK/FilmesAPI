using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        DBContext _context;
        private readonly IMapper _mapper;

        public EnderecoService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool adicionarEndereco(Endereco endereco)
        {
            bool status = false;

            if (endereco != null)
            {
                _context.Add(endereco);
                _context.SaveChanges();
                return true;
            }

            return status;
        }

        public IEnumerable<Endereco> getEnderecos()
        {
            IEnumerable<Endereco> endereco = _context.Enderecos;
            return endereco;
        }

        public Cinema atualizarEndereco(int id, Endereco enderecoNovo)
        {
            Cinema endereco = _context.Cinemas.FirstOrDefault(x => x.Id == id); //pega o primeiro que encontrar com o id fornecido ou retorna null

            _mapper.Map(enderecoNovo, endereco);
            _context.SaveChanges();

            return endereco;
        }

        public bool RemoverTodos()
        {
            IEnumerable<Endereco> enderecos = _context.Enderecos;
            _context.Enderecos.RemoveRange(enderecos);
            _context.SaveChanges();
            return true;
        }
    }

}
