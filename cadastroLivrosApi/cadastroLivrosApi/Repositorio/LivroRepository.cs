using cadastroLivrosApi.Contextos;
using cadastroLivrosApi.Models;
using cadastroLivrosApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Repositorio
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContexto context;


        public LivroRepository(AppDbContexto context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Livro>> GetLivrosAsync()
        {
            return await context.Livros
              .Include(p => p.Autores)
              .AsNoTracking().ToListAsync();
        }

        public async Task<Livro> GetLivroAsync(int id)
        {
            return await context.Livros
                .Include(p => p.Autores)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Livro> InsertLivroAsync(Livro livro)
        {
            await InsertLivroAutores(livro);
            await context.Livros.AddAsync(livro);
            await context.SaveChangesAsync();
            return livro;
        }

        private async Task InsertLivroAutores(Livro livro)
        {
            var autoresConsultados = new List<Autores>();
            foreach (var autor in livro.Autores)
            {
                var autoresConsultado = await context.Autores.FindAsync(autor.Id);
                autoresConsultados.Add(autoresConsultado);
            }
            livro.Autores = autoresConsultados;
        }

        public async Task<Livro> UpdateLivroAsync(Livro livro)
        {
            var livroConsultado = await context.Livros
                                    .Include(p => p.Autores)
                                    .SingleOrDefaultAsync(p => p.Id == livro.Id);
            if (livroConsultado == null)
            {
                return null;
            }
            context.Entry(livroConsultado).CurrentValues.SetValues(livro);
            await UpdateLivroAutores(livro, livroConsultado);
            await context.SaveChangesAsync();
            return livroConsultado;
        }

        private async Task UpdateLivroAutores(Livro livro, Livro livroConsultado)
        {
            livroConsultado.Autores.Clear();
            foreach (var autor in livro.Autores)
            {
                var autorConsultado = await context.Autores.FindAsync(autor.Id);
               livroConsultado.Autores.Add(autorConsultado);
            }
        }
        
        public async Task<Livro> DeleteLivroAsync(int id)
        {
            var livroConsultado = await context.Livros.FindAsync(id);
            if (livroConsultado == null)
            {
                return null;
            }
            var livroRemovido = context.Livros.Remove(livroConsultado);
            await context.SaveChangesAsync();
            return livroRemovido.Entity;
        }
    }
 }

    

    






