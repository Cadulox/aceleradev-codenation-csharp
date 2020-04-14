using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly ICardapioRepositorio _repo;

        public IngredienteController(ICardapioRepositorio repo)
        {
            _repo = repo;
        }
        // GET: api/Ingrediente
        [HttpGet]
        public IEnumerable<Cardapio> Get()
        {
            return _repo.SelecionarTodos();
        }

        // GET: api/Ingrediente/5
        [HttpGet("{id}")]
        public Cardapio Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }

        // POST: api/Ingrediente
        [HttpPost]
        public Cardapio Post([FromBody] Cardapio ingrediente)
        {
            _repo.Incluir(ingrediente);
            return ingrediente;
        }

        // PUT: api/Ingrediente/5
        [HttpPut]
        public Cardapio Put([FromBody] Cardapio ingrediente)
        {
            _repo.Alterar(ingrediente);
            return ingrediente;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Cardapio> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTodos();
        }
    }
}
