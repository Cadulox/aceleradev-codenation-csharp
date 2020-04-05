﻿using System;
using System.Collections.Generic;

namespace RestauranteCodenation.Domain
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
        public List<PratosIngredientes> PratosIngredientes { get; set; }
    }
}
