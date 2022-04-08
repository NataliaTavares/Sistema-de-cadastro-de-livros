using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public interface ILivrosService
    {
        Task DeleteLivroAsync(int id);

        Task<LivroView> GetLivroAsync(int id);

        Task<IEnumerable<LivroView>> GetLivrosAsync();

        Task<LivroView> InsertLivroAsync(NovoLivro novoLivro);

        Task<LivroView> UpdateLivroAsync(AlteraLivro alteraLivro);

    }
}
