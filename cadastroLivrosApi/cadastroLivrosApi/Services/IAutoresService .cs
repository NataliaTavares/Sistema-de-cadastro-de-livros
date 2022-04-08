using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public interface IAutoresService
    {
        Task DeleteAutorAsync(int id);

        Task<AutoresView> GetAutorAsync(int id);

        Task<IEnumerable<AutoresView>> GetAutoresAsync();

        Task<AutoresView> InsertAutorAsync(NovoAutor novoAutor);

        Task<AutoresView> UpdateAutorAsync(AlteraAutor alteraAutor);

    }
}
