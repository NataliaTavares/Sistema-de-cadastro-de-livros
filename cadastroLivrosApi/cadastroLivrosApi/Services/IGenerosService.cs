using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Generos;
using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public interface IGenerosService
    {
        Task DeleteGeneroAsync(int id);

        Task<GeneroView> GetGeneroAsync(int id);

        Task<IEnumerable<GeneroView>> GetGenerosAsync();

        Task<GeneroView> InsertGeneroAsync(NovoGenero novoGenero);

        Task<GeneroView> UpdateGeneroAsync(AlteraGenero alteraGenero);

    }
}
