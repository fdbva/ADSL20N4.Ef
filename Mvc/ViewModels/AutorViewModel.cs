﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mvc.ViewModels
{
    public class AutorViewModel : BaseViewModel
    {
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
