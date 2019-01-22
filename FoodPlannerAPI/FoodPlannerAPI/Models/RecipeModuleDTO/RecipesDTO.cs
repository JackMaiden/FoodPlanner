using System.Collections.Generic;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class RecipesDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public int Servings { get; set; }

        public string ServingSize { get; set; }

        public string Tips { get; set; }

        public virtual IEnumerable<int> MealTypes { get; set; }

        public virtual IEnumerable<int> FoodFilters { get; set; }

        public virtual IEnumerable<int> Allergens { get; set; }

        public int Nutrition { get; set; }

        public virtual IEnumerable<int> Ingredients { get; set; }

        public virtual IEnumerable<int> MethodSteps { get; set; }
    }
}