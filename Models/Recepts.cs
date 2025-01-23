using System.Collections.Generic;

namespace ReceptenApi.Models
{
    public class Recept
    {
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public List<Ingredient> Ingredienten { get; set; }
        public string Afbeelding { get; set; }
    }
}
