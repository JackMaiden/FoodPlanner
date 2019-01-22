using System.Collections.Generic;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class IngredientsDTO
    {
        public int Id { get; set; }

        public string Ingredient { get; set; }

        public int Recipe { get; set; }
    }
}