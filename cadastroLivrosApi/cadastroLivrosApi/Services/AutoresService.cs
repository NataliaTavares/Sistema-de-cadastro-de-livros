﻿using cadastroLivrosApi.Models;
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

        public async Task<IEnumerable<AutorView>> GetAutoresAsync()
        {
            return mapper.Map<IEnumerable<Autores>, IEnumerable<AutorView>>(await repository.GetAutoresAsync());
        }

        public async Task<AutorView> GetAutorAsync(int id)
        {
            return mapper.Map<AutorView>(await repository.GetAutorAsync(id));
        }

        public async Task<AutorView> InsertAutorAsync(NovoAutor novoAutor)
        {
            var autor = mapper.Map<Autores>(novoAutor);
            return mapper.Map<AutorView>(await repository.InsertAutorAsync(autor));
        }

        public async Task DeleteAutorAsync(int id)
        {
            await repository.DeleteAutorAsync(id);
        }

        public async Task<AutorView> UpdateAutorAsync(AlteraAutor alteraAutor)
        {
            var autor = mapper.Map<Autores>(alteraAutor);
            return mapper.Map<AutorView>(await repository.UpdateAutorAsync(autor));
        }
    }
}
