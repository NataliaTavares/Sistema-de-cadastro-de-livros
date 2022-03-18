using cadastroLivrosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public interface ILivrosService
    {
        Task<IEnumerable<Livro>> GetLivros();

        Task<Livro> GetLivro(int id);

        Task<IEnumerable<Livro>> GetLivrosByNome(string nome);

        Task CreateLivro(Livro livro);

        Task UpdateLivro(Livro livro);

        Task DeleteLivro(Livro livro);
    }
}
