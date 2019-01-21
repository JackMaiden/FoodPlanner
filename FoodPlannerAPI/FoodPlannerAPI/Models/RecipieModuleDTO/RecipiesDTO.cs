using System.Collections.Generic;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class RecipiesDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public int Servings { get; set; }

        public string ServingSize { get; set; }

        public string Tips { get; set; }

        public virtual ICollection<int> MealTypes { get; set; }

        public virtual ICollection<int> FoodFilters { get; set; }

        public virtual ICollection<int> Allergens { get; set; }

        public int Nutrition { get; set; }

        public virtual ICollection<int> Ingredients { get; set; }

        public virtual ICollection<int> MethodSteps { get; set; }
    }
}