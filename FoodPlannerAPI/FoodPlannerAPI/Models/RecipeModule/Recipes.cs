using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodPlannerAPI.Models.RecipieModule;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class Recipes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public int Servings { get; set; }

        public string ServingSize { get; set; }

        public string Tips { get; set; }

        //[JsonIgnore]
        public virtual ICollection<MealTypes> MealTypes { get; set; }

        //[JsonIgnore]
        public virtual ICollection<FoodFilters> FoodFilters { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Allergens> Allergens { get; set; }
        
        //[JsonIgnore]
        public Nutrition Nutrition { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Ingredients> Ingredients { get; set; }

        //[JsonIgnore]
        public virtual ICollection<MethodSteps> MethodSteps { get; set; }
    }
}