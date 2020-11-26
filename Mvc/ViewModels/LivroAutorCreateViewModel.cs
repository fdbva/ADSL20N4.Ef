using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.ViewModels
{
    public class LivroAutorCreateViewModel
    {
        [Required]
        public string Titulo { get; set; }

        [Remote(controller: "Livro", action: "IsIsbnValid")]
        public string Isbn { get; set; }
        public DateTime Publicacao { get; set; }

        [DisplayName("Autor")]
        public int? AutorId { get; set; }
        public AutorViewModel Autor { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
    }
}
