﻿using System.Collections.Generic;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class AllergensDTO
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<int> Recipies { get; set; }
    }
}