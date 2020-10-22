using System;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class AutorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime Nascimento { get; set; }

        public List<LivroViewModel> Livros { get; set; }

        public string AutorNomeCompleto => $"({Id}) {Nome} {UltimoNome}";
    }
}
