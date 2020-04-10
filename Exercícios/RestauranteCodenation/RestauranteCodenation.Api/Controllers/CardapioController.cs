using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly CardapioRepositorio _repo;

        public CardapioController()
        {
            _repo = new CardapioRepositorio();
        }

        [HttpGet]
        public IEnumerable<Cardapio> Get()
        {
            return _repo.SelecionarTodos();
        }

        [HttpGet("{id}")]
        public Cardapio Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        [HttpPost]
        public Cardapio Post([FromBody] Cardapio cardapio)
        {
            _repo.Incluir(cardapio);
            return cardapio;
        }

        [HttpPut]
        public Cardapio Put([FromBody] Cardapio cardapio)
        {
            _repo.Alterar(cardapio);
            return cardapio;
        }

        [HttpDelete("{id}")]
        public List<Cardapio> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
