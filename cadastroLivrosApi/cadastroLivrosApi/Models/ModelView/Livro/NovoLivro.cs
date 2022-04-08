using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using cadastroLivrosApi.Models.ModelView.Autores;

namespace cadastroLivrosApi.Models.ModelView.Livro
{
    public class NovoLivro
    {

        public string Nome { get; set; }


        [DataType(DataType.Date)]
        public DateTime Data { get; set; }


        [StringLength(80)]
        public string Genero { get; set; }


        public ICollection<ReferenciaAutor> Autores { get; set; }
    }
}

