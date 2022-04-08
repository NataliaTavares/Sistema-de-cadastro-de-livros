using System.Collections.Generic;

namespace cadastroLivrosApi.Models
{
    public class Autores
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Livro> Livro { get; set; }
    }
}