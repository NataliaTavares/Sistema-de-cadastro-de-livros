


using cadastroLivrosApi.Models.ModelView.Autores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace cadastroLivrosApi.Models.ModelView.Livro
{
    public class LivroView
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public ICollection<AutoresView> Autores { get; set; }
    }
}

