using cadastroLivrosApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public interface IGenerosRepository
    {
        Task<IEnumerable<Generos>> GetGenerosAsync();

        Task<Generos> GetGeneroAsync(int id);

        Task<Generos> InsertGeneroAsync(Generos genero);

        Task<Generos> UpdateGeneroAsync(Generos genero);

        Task<Generos> DeleteGeneroAsync(int id);
    }
}

