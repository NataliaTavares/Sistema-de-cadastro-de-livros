using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;

namespace cadastroLivrosApi.Models.ModelView.Generos
{
    public class GeneroView
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<LivroViewNome> Livro { get; set; }
    }
};

