using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModels
{
    public class LivroAutorCreateRequest
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
    }
}
