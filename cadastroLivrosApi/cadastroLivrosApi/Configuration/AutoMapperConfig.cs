using cadastroLivrosApi.Mapeamento;
using Microsoft.Extensions.DependencyInjection;

namespace cadastroLivrosApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovoLivroMappingProfile));
        }
    }
}

