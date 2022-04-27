using cadastroLivrosApi.Models;
using System.Threading.Tasks;
using AutoMapper;
using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;
using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Generos;

namespace cadastroLivrosApi.Services
{
    public class GenerosService: IGenerosService
    {

        private readonly IGenerosRepository repository;
        private readonly IMapper mapper;


        public GenerosService(IGenerosRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GeneroView>> GetGenerosAsync()
        {
            return mapper.Map<IEnumerable<Generos>, IEnumerable<GeneroView>>(await repository.GetGenerosAsync());
        }

        public async Task<GeneroView> GetGeneroAsync(int id)
        {
            return mapper.Map<GeneroView>(await repository.GetGeneroAsync(id));
        }

        public async Task<GeneroView> InsertGeneroAsync(NovoGenero novoGenero)
        {
            var genero = mapper.Map<Generos>(novoGenero);
            return mapper.Map<GeneroView>(await repository.InsertGeneroAsync(genero));
        }

        public async Task DeleteGeneroAsync(int id)
        {
            await repository.DeleteGeneroAsync(id);
        }

        public async Task<GeneroView> UpdateGeneroAsync(AlteraGenero alteraGenero)
        {
            var genero = mapper.Map<Generos>(alteraGenero);
            return mapper.Map<GeneroView>(await repository.UpdateGeneroAsync(genero));
        }
    }
}
