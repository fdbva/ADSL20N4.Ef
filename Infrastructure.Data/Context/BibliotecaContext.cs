using System.Diagnostics;
using Domain.Model.Models;
using Infrastructure.Data.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(message => Debug.WriteLine(message));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AutorEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AutorEntity> Autores { get; set; }

        public DbSet<LivroEntity> Livros { get; set; }
    }
}
