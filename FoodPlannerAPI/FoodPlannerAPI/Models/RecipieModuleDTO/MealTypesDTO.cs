using System.Collections.Generic;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class MealTypesDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<int> Recipies { get; set; }
    }
}