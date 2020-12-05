using System;

namespace Domain.Model.Models
{
    public class LivroEntity : BaseEntity
    {
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public DateTime Publicacao { get; set; }

        public int AutorId { get; set; }
        public AutorEntity Autor { get; set; }
    }
}
