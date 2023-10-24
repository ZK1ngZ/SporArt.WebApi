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

        [Required]
        public DbSet<Usuario> Usuarios { get; set; }
       

        public DbSet<Mensagem> Mensagens { get; set; }

        public DbSet<Item> Itens { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Foto> Fotos { get; set; }

        public DbSet<Pintura> Pinturas { get; set; }

        public DbSet<Musica> Musicas { get; set; }

    }
}
