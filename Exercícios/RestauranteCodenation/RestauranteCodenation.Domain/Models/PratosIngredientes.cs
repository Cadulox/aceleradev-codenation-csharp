﻿using RestauranteCodenation.Domain.Repositorio;

namespace RestauranteCodenation.Domain
{
    public class PratosIngredientes : IEntity
    {
        public int Id { get; set; }
        public int IdPrato { get; set; }
        public Prato Prato { get; set; }

        public int IdIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
