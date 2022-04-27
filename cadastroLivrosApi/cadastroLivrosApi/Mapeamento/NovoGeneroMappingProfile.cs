using AutoMapper;
using cadastroLivrosApi.Models;
using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Generos;
using cadastroLivrosApi.Models.ModelView.Livro;


namespace cadastroLivrosApi.Mapeamento
{
    public class NovoGeneroMappingProfile : Profile
    {
        public NovoGeneroMappingProfile()
        {
            CreateMap<NovoGenero, Generos>();
            CreateMap<Generos, GeneroView>();
            CreateMap<Livro, ReferenciaLivro>().ReverseMap();
            CreateMap<Livro, LivroViewNome>().ReverseMap();
            CreateMap<Livro, NovoLivro>().ReverseMap();
            CreateMap<AlteraGenero, Generos>().ReverseMap();



        }
    }
}

