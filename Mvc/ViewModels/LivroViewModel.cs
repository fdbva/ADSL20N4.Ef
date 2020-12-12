﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.ViewModels
{
    public class LivroViewModel : BaseViewModel
    {
        public string Titulo { get; set; }

        [Remote(controller: "Livro", action: "IsIsbnValid", AdditionalFields = nameof(Id))]
        public string Isbn { get; set; }
        public DateTime Publicacao { get; set; }

        public int AutorId { get; set; }
        public AutorViewModel Autor { get; set; }
    }
}
