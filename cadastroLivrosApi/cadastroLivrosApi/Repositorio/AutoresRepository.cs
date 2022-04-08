using cadastroLivrosApi.Contextos;
using cadastroLivrosApi.Models;
using cadastroLivrosApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Repositorio
{
    public class AutoresRepository : IAutoresRepository
    {
        private readonly AppDbContexto context;

        public AutoresRepository(AppDbContexto context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Autores>> GetAutoresAsync()
        {
            return await context.Autores
              //.Include(p => p.Autores)
              .AsNoTracking().ToListAsync();
        }

        public async Task<Autores> GetAutorAsync(int id)
        {
            return await context.Autores
     
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Autores> InsertAutorAsync(Autores autor)
        {
            //await InsertLivroAutores(autor);
            await context.Autores.AddAsync(autor);
            await context.SaveChangesAsync();
            return autor;
        }

        /*private async Task InsertLivroAutores(Livro livro)
        {
            var autoresConsultados = new List<Autores>();
            foreach (var autor in livro.Autores)
            {
                var autoresConsultado = await context.Autores.FindAsync(autor.Id);
                autoresConsultados.Add(autoresConsultado);
            }
            livro.Autores = autoresConsultados;
        }*/



        public async Task<Autores> DeleteAutorAsync(int id)
        {
            var autorConsultado = await context.Autores.FindAsync(id);
            if (autorConsultado == null)
            {
                return null;
            }
            var autorRemovido = context.Autores.Remove(autorConsultado);
            await context.SaveChangesAsync();
            return autorRemovido.Entity;
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await context.Autores.AnyAsync(p => p.Id == id);
        }

        public async Task<Autores> UpdateAutorAsync(Autores autor)
        {
            var autorConsultado = await context.Autores
                                    //.Include(p => p.Autores)
                                    .SingleOrDefaultAsync(p => p.Id == autor.Id);
            if (autorConsultado == null)
            {
                return null;
            }
            context.Entry(autorConsultado).CurrentValues.SetValues(autor);
            //await UpdateLivroAutores(autor, autorConsultado);
            await context.SaveChangesAsync();
            return autorConsultado;
        }

        /*private async Task UpdateLivroAutores(Autores autor, Autores autorConsultado)
        {
            autorConsultado.Livro.Clear();
            foreach (var livro in autor.Livro)
            {
                var livroConsultado = await context.Livros.FindAsync(livro.Id);
                autorConsultado.Livro.Add(livroConsultado);
            }
        }*/


    }
}

