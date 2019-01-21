using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class Nutrition
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Units { get; set; }

        public int EnergyKJ { get; set; }

        public int EnergyKCal { get; set; }

        public double Fat { get; set; }

        public double Saturates { get; set; }

        public double Carbohydrates { get; set; }

        public double Sugars { get; set; }

        public double Protein { get; set; }

        public double Salt { get; set; }
    }
}