using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public interface IAutoresService
    {
        Task DeleteAutorAsync(int id);

        Task<AutorView> GetAutorAsync(int id);

        Task<IEnumerable<AutorView>> GetAutoresAsync();

        Task<AutorView> InsertAutorAsync(NovoAutor novoAutor);

        Task<AutorView> UpdateAutorAsync(AlteraAutor alteraAutor);

    }
}
