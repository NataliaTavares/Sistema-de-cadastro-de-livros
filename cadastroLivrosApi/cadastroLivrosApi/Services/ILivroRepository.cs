using cadastroLivrosApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetLivrosAsync();

        Task<Livro> GetLivroAsync(int id);

        Task<Livro> InsertLivroAsync(Livro livro);

        Task<Livro> UpdateLivroAsync(Livro livro);

        Task<Livro> DeleteLivroAsync(int id);
    }
}

