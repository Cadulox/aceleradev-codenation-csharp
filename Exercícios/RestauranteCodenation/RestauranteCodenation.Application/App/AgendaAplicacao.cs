using AutoMapper;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.ViewModel;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;

namespace RestauranteCodenation.Application.App
{
    public class AgendaAplicacao : IAgendaAplicacao
    {
        private readonly IAgendaRepositorio _repo;
        private readonly IMapper _mapper;
        public AgendaAplicacao(IAgendaRepositorio repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public void Alterar(AgendaCardapioViewModel entity)
        {
            _repo.Alterar(_mapper.Map<Agenda>(entity));
        }

        public void Excluir(int id)
        {
            _repo.Excluir(id);
        }

        public void Incluir(AgendaCardapioViewModel entity)
        {
            _repo.Incluir(_mapper.Map<Agenda>(entity));
        }

        public AgendaCardapioViewModel SelecionarPorId(int id)
        {
            return _mapper.Map<AgendaCardapioViewModel>(_repo.SelecionarPorId(id));
        }

        public List<AgendaCardapioViewModel> SelecionarTodos()
        {
            return _mapper.Map<List<AgendaCardapioViewModel>>(_repo.SelecionarTodos());
        }
    }
}
