using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodPlannerAPI.Models
{
    public class FoodPlannerAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FoodPlannerAPIContext() : base("name=FoodPlannerAPIContext")
        {
        }

        public System.Data.Entity.DbSet<FoodPlannerAPI.Models.RecipieModule.MealTypes> MealTypes { get; set; }

        public System.Data.Entity.DbSet<FoodPlannerAPI.Models.RecipieModule.Allergens> Allergens { get; set; }

        public System.Data.Entity.DbSet<FoodPlannerAPI.Models.RecipieModule.FoodFilters> FoodFilters { get; set; }

        public System.Data.Entity.DbSet<FoodPlannerAPI.Models.RecipieModule.Ingredients> Ingredients { get; set; }

        public System.Data.Entity.DbSet<FoodPlannerAPI.Models.RecipieModule.MethodSteps> MethodSteps { get; set; }

        public System.Data.Entity.DbSet<FoodPlannerAPI.Models.RecipieModule.Nutrition> Nutritions { get; set; }

        public System.Data.Entity.DbSet<FoodPlannerAPI.Models.RecipieModule.Recipies> Recipies { get; set; }
    }
}
