using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Context.Configurations
{
    public class LivroEntityConfiguration : IEntityTypeConfiguration<LivroEntity>
    {
        public void Configure(EntityTypeBuilder<LivroEntity> builder)
        {
            builder
                .HasOne(x => x.Autor)
                .WithMany(x => x.Livros);
        }
    }
}
