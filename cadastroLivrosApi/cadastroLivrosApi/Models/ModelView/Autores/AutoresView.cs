using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;

namespace cadastroLivrosApi.Models.ModelView.Autores
{
    public class AutoresView
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<LivroViewNome> Livro { get; set; }
    }
};

