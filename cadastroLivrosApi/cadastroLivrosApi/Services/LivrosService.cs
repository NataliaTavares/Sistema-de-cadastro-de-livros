using cadastroLivrosApi.Contextos;
using cadastroLivrosApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Services
{
    public class LivrosService : ILivrosService
    {
        private readonly AppDbContexto _context;

        public LivrosService(AppDbContexto context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> GetLivros()
        {
            try
            {
                return await _context.Livros.ToListAsync();
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<Livro>> GetLivrosByNome(string nome)
        {
            IEnumerable<Livro> livros;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                livros = await _context.Livros.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                livros = await GetLivros();
            }
            return livros;  
        }


        public async Task<Livro> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            return livro;
        }

        public async Task CreateLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLivro(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

    }
}
