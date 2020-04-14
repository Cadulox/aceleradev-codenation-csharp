using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Application.ViewModel
{
    public class AgendaCardapioViewModel
    {
        public int Id { get; set; }
        public int IdCardapio { get; set; }
        public Cardapio Cardapio { get; set; }

        public int IdAgenda { get; set; }
        public Agenda Agenda { get; set; }
    }
}
