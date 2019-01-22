﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodPlannerAPI.Models.RecipieModule;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class FoodFilters
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        //[JsonIgnore]
        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}