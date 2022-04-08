using cadastroLivrosApi.Repositorio;
using cadastroLivrosApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace cadastroLivrosApi.Configuration
{

    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ILivrosService, LivrosService>();
            services.AddScoped<IAutoresRepository, AutoresRepository>();

        }

    }
}

