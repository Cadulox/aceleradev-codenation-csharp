using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Domain
{
    public class AgendaCardapio : IEntity
    {
        public int Id { get; set; }
        public int IdCardapio { get; set; }
        public Cardapio Cardapio { get; set; }

        public int IdAgenda { get; set; }
        public Agenda Agenda { get; set; }
    }
}
