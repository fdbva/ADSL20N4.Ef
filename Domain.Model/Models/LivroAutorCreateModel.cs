using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model.Models
{
    public class LivroAutorCreateModel : BaseEntity
    {
        [Required]
        public string Titulo { get; set; }

        public string Isbn { get; set; }
        public DateTime Publicacao { get; set; }

        public int? AutorId { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public LivroEntity ToLivroEntity()
        {
            var livroEntity = new LivroEntity
            {
                Titulo = Titulo,
                Isbn = Isbn,
                Publicacao = Publicacao,
                AutorId = AutorId ?? 0,
            };

            return livroEntity;
        }

        public AutorEntity ToAutorEntity()
        {
            var autorEntity = new AutorEntity
            {
                Nome = Nome,
                UltimoNome = UltimoNome,
                Nascimento = Nascimento
            };

            return autorEntity;
        }
    }
}
