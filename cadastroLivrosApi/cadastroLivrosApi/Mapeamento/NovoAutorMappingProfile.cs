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
            //CreateMap<Autores, ReferenciaAutor>().ReverseMap();
            //CreateMap<Autores, AutoresView>().ReverseMap();
            //CreateMap<Autores, NovoAutor>().ReverseMap();
            CreateMap<AlteraAutor, Autores>().ReverseMap();



        }
    }
}

