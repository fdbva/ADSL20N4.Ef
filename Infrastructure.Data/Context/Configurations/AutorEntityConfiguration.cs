using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Configurations
{
    public class AutorEntityConfiguration : IEntityTypeConfiguration<AutorEntity>
    {
        public void Configure(EntityTypeBuilder<AutorEntity> builder)
        {
            builder
                .HasMany(x => x.Livros)
                .WithOne(x => x.Autor);

            builder
                .Property(x => x.Nome)
                .HasMaxLength(100);
        }
    }
}
