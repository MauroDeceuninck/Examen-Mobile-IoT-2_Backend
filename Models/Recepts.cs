using System.Collections.Generic;

namespace ReceptenApi.Models
{
    public class Recept
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public List<Ingredient> Ingredienten { get; set; } = new();
        public string Afbeelding { get; set; }
    }
}
