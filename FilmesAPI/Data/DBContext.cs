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

        //relacionar classes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema) //endereço possui 1 cinema
                .WithOne(cinema => cinema.Endereco) //cinema possui 1 endereço
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); //define a Foreign key (EnderecoId) na classe Cinema

            modelBuilder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas) //muitos
                .HasForeignKey(cinema => cinema.GerenteId);
        }

        //mapear classes
        public DbSet<Filme> Filmes { get; set; } //DbSet<Filme> é a classe que vamos mapear // Filmes é o nome da tabela banco de dados
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes{ get; set; }
    }
}
