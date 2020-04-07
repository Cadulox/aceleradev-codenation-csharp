using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Domain
{
    public class Cardapio : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<AgendaCardapio> AgendaCardapios { get; set; }
        public List<Prato> Pratos { get; set; }
    }
}
