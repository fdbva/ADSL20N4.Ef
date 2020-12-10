﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.RequestContracts
{
    public class LivroRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [Remote(controller: "Livro", action: "IsIsbnValid", AdditionalFields = nameof(Id))]
        public string Isbn { get; set; }
        public DateTime Publicacao { get; set; }

        public int AutorId { get; set; }
        public AutorRequest Autor { get; set; }
    }
}