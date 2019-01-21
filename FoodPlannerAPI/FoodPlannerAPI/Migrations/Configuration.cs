namespace FoodPlannerAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FoodPlannerAPI.Models.RecipieModule;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodPlannerAPI.Models.FoodPlannerAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FoodPlannerAPI.Models.FoodPlannerAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.MealTypes.AddOrUpdate(
                mt => mt.Name,
                new MealTypes { Name = "Breakfast" },
                new MealTypes { Name = "Lunch" },
                new MealTypes { Name = "Dinner" }
            );

            context.Allergens.AddOrUpdate(
                a => a.Name,
                new Allergens { Name = "Nuts" },
                new Allergens { Name = "Dairy" },
                new Allergens { Name = "Gluten" }
            );

            context.FoodFilters.AddOrUpdate(
                f => f.Name,
                new FoodFilters { Name = "Chicken" },
                new FoodFilters { Name = "Lamb" },
                new FoodFilters { Name = "Beef" }
            );
        }
    }
}
