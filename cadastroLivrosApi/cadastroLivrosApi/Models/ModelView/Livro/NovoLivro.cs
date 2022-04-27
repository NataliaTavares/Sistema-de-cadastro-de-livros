using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Generos;

namespace cadastroLivrosApi.Models.ModelView.Livro
{
    public class NovoLivro
    {

        public string Nome { get; set; }


        [DataType(DataType.Date)]
        public DateTime Data { get; set; }


        public ICollection<ReferenciaGenero> Genero { get; set; }


        public ICollection<ReferenciaAutor> Autores { get; set; }
    }
}

