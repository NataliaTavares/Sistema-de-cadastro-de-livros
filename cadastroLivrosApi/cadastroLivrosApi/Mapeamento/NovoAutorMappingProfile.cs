using AutoMapper;
using cadastroLivrosApi.Models;
using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Livro;


namespace cadastroLivrosApi.Mapeamento
{
    public class NovoAutorMappingProfile : Profile
    {
        public NovoAutorMappingProfile()
        {
            CreateMap<NovoAutor, Autores>();
            CreateMap<Autores, AutoresView>();
            CreateMap<Livro, ReferenciaLivro>().ReverseMap();
            CreateMap<Livro, LivroViewNome>().ReverseMap();
            CreateMap<Livro, NovoLivro>().ReverseMap();
            CreateMap<AlteraAutor, Autores>().ReverseMap();



        }
    }
}

