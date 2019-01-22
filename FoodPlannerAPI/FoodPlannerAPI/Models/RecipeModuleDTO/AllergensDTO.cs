using System.Collections.Generic;

namespace FoodPlannerAPI.Models.RecipieModule
{
    public class AllergensDTO
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<int> Recipes { get; set; }
    }
}