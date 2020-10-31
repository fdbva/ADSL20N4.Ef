using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class AutorViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        public List<LivroViewModel> Livros { get; set; }

        public string AutorNomeCompleto => $"({Id}) {Nome} {UltimoNome}";
    }
}
