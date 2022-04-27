using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cadastroLivrosApi.Models
{
    public class Generos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Livro> Livro { get; set; }


        public Generos()
        {
            Livro = new HashSet<Livro>();
        }
    }
}