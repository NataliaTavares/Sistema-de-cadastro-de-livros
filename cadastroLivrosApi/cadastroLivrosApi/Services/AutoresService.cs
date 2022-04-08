using cadastroLivrosApi.Models;
using System.Threading.Tasks;
using AutoMapper;
using cadastroLivrosApi.Models.ModelView.Livro;
using System.Collections.Generic;
using cadastroLivrosApi.Models.ModelView.Autores;

namespace cadastroLivrosApi.Services
{
    public class AutoresService: IAutoresService
    {

        private readonly IAutoresRepository repository;
        private readonly IMapper mapper;


        public AutoresService(IAutoresRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AutoresView>> GetAutoresAsync()
        {
            return mapper.Map<IEnumerable<Autores>, IEnumerable<AutoresView>>(await repository.GetAutoresAsync());
        }

        public async Task<AutoresView> GetAutorAsync(int id)
        {
            return mapper.Map<AutoresView>(await repository.GetAutorAsync(id));
        }

        public async Task<AutoresView> InsertAutorAsync(NovoAutor novoAutor)
        {
            var autor = mapper.Map<Autores>(novoAutor);
            return mapper.Map<AutoresView>(await repository.InsertAutorAsync(autor));
        }

        public async Task DeleteAutorAsync(int id)
        {
            await repository.DeleteAutorAsync(id);
        }

        public async Task<AutoresView> UpdateAutorAsync(AlteraAutor alteraAutor)
        {
            var autor = mapper.Map<Autores>(alteraAutor);
            return mapper.Map<AutoresView>(await repository.UpdateAutorAsync(autor));
        }
    }
}
