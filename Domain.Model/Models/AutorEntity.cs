using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class AutorEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime Nascimento { get; set; }

        public List<LivroEntity> Livros { get; set; }
    }
}
