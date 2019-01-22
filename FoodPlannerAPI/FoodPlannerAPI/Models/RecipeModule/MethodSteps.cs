using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodPlannerAPI.Models.RecipieModule;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class MethodSteps
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StepNo { get; set; }

        [Required]
        public string Step { get; set; }

        [Required]
        public Recipes Recipie { get; set; }
    }
}