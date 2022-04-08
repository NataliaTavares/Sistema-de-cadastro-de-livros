using AutoMapper;
using cadastroLivrosApi.Models;
using cadastroLivrosApi.Models.ModelView.Autores;
using cadastroLivrosApi.Models.ModelView.Livro;


namespace cadastroLivrosApi.Mapeamento
{
    public class NovoLivroMappingProfile : Profile
    {
        public NovoLivroMappingProfile()
        {
            CreateMap<NovoLivro, Livro>();
            CreateMap<Livro, LivroView>();
            CreateMap<Autores, ReferenciaAutor>().ReverseMap();
            CreateMap<Autores, AutoresView>().ReverseMap();
            CreateMap<Autores, NovoAutor>().ReverseMap();
            CreateMap<AlteraLivro, Livro>().ReverseMap();



        }
    }
}

