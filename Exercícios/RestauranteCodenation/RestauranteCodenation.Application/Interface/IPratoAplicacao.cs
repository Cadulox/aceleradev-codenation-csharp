using RestauranteCodenation.Application.ViewModel;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.Interface
{
    public interface IPratoAplicacao
    {
        void Incluir(PratoViewModel entity);
        void Alterar(PratoViewModel entity);
        PratoViewModel SelecionarPorId(int id);
        void Excluir(int id);
        List<PratoViewModel> SelecionarTodos();
    }
}
