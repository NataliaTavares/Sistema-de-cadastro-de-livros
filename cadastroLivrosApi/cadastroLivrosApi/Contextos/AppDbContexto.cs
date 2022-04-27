using cadastroLivrosApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastroLivrosApi.Contextos
{
    public class AppDbContexto: DbContext
    {

        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options)
        {

        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Generos> Generos { get; set; }

        
    }
}
