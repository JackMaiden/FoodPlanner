using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodPlannerAPI.Models.RecipieModule;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ingredient { get; set; }

        [Required]
        public Recipes Recipe { get; set; }
    }
}