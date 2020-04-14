using AutoMapper;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }
        public AutoMapperConfig()
        {
            CreateMap<AgendaCardapio, AgendaCardapioViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaCardapioViewModel>().ReverseMap();
            CreateMap<Cardapio, CardapioViewModel>().ReverseMap();
            CreateMap<Cardapio, CardapioViewModel>().ReverseMap();
            CreateMap<PratosIngredientes, PratosIngredientesViewModel>().ReverseMap();
            CreateMap<Prato, PratoViewModel>().ReverseMap();
            CreateMap<TipoPrato, TipoPratoViewModel>().ReverseMap();
        }
    }
}
