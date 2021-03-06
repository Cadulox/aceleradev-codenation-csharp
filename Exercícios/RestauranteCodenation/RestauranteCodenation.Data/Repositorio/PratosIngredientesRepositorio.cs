﻿using Microsoft.EntityFrameworkCore;
using RestauranteCodenation.Domain;
using RestauranteCodenation.Domain.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteCodenation.Data.Repositorio
{
    public class PratosIngredientesRepositorio : RepositorioBase<PratosIngredientes>, IPratosIngredientesRepositorio
    {
        public PratosIngredientesRepositorio(Contexto contexto) : base(contexto)
        {
        }
        public List<PratosIngredientes> SelecionarCompleto()
        {
            return _contexto
                .PratosIngredientes
                .Include(x => x.Ingrediente)
                .Include(x => x.Prato)
                .Include(x => x.Prato.TipoPrato)
                .ToList();
        }
    }
}
