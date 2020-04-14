using RestauranteCodenation.Domain;

namespace RestauranteCodenation.Application.ViewModel
{
    public class PratosIngredientesViewModel
    {
        public int Id { get; set; }
        public int IdPrato { get; set; }
        public Prato Prato { get; set; }

        public int IdIngrediente { get; set; }
        public Cardapio Ingrediente { get; set; }
    }
}
