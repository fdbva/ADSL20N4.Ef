using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<AutorEntity> Autores { get; set; }

        public DbSet<LivroEntity> Livros { get; set; }
    }
}
