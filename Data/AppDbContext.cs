using Microsoft.EntityFrameworkCore;
using SporArt.Models;

using SpotClass;
using System.ComponentModel.DataAnnotations;


namespace SporArt.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Usuario> Usuarios { get; set; }


        public DbSet<Mensagem> Mensagens { get; set; }

        public DbSet<Item> Itens { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Foto> Fotos { get; set; }

        public DbSet<Pintura> Pinturas { get; set; }

        public DbSet<Musica> Musicas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasData(
                    new Usuario
                    {
                        Id = 1,
                        Nome = "Senai ADMIN",
                        Email = "senaiadm@gmail.com",
                        Senha = "Senai321",
                      
                    },
                    new Usuario
                    {
                        Id = 2,
                        Nome = "Senai Aluno",
                        Email = "senaialuno@gmail.com",
                        Senha = "Senai123",
                     
                    }
                );


        }
    }
}
