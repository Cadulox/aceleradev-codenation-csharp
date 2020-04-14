using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface IAgendaAplicacao
    {
        void Incluir(AgendaCardapioViewModel entity);
        void Alterar(AgendaCardapioViewModel entity);
        AgendaCardapioViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<AgendaCardapioViewModel> SelecionarTodos();
    }
}
