﻿namespace RestauranteCodenation.Domain
{
    public class PratosIngredientes
    {
        public int IdPrato { get; set; }
        public Prato Prato { get; set; }

        public int IdIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
