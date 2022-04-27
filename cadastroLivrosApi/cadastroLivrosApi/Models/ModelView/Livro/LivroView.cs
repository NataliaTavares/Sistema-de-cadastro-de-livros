﻿using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Generos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace cadastroLivrosApi.Models.ModelView.Livro
{
    public class LivroView
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public ICollection<GeneroView> Genero { get; set; }

        public ICollection<AutorView> Autores { get; set; }
    }
}

