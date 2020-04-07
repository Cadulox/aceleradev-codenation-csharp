using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteRepositorio _ingredienteRepositorio;

        public IngredienteController()
        {
            _ingredienteRepositorio = new IngredienteRepositorio();
        }
        // GET: api/Ingrediente
        [HttpGet]
        public IEnumerable<Ingrediente> Get()
        {
            return _ingredienteRepositorio.SelecionarTodos();
        }

        // GET: api/Ingrediente/5
        [HttpGet("{id}", Name = "Get")]
        public Ingrediente Get(int id)
        {
            return _ingredienteRepositorio.SelecionarPorId(id);
        }

        // POST: api/Ingrediente
        [HttpPost]
        public Ingrediente Post([FromBody] Ingrediente ingrediente)
        {
            _ingredienteRepositorio.Incluir(ingrediente);
            return ingrediente;
        }

        // PUT: api/Ingrediente/5
        [HttpPut]
        public Ingrediente Put([FromBody] Ingrediente ingrediente)
        {
            _ingredienteRepositorio.Alterar(ingrediente);
            return ingrediente;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Ingrediente> Delete(int id)
        {
            _ingredienteRepositorio.Excluir(id);
            return _ingredienteRepositorio.SelecionarTodos();
        }
    }
}
