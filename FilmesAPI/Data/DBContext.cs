using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    public class DBContext : DbContext //essa classe herda da classe DbContext
    {
        
        public DBContext(DbContextOptions<DBContext> option) : base(option) //Construtor
        {

        }

        //mapear classes
        public DbSet<Filme> Filmes { get; set; } //DbSet<Filme> é a classe que vamos mapear // Filmes é o nome da tabela banco de dados
    }
}
