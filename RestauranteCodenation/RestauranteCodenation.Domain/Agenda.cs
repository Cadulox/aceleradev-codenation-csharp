using System;
using System.Collections.Generic;

namespace RestauranteCodenation.Domain
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<AgendaCardapio> AgendaCardapios { get; set; }
    }
}
