using System;

namespace Application.ViewModels
{
    public class LivroViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public DateTime Publicacao { get; set; }

        public int AutorId { get; set; }
        public AutorViewModel Autor { get; set; }
    }
}
