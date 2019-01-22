namespace FoodPlannerAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allergens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        PrepTime = c.String(),
                        CookTime = c.String(),
                        Servings = c.Int(nullable: false),
                        ServingSize = c.String(),
                        Tips = c.String(),
                        Nutrition_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nutritions", t => t.Nutrition_ID)
                .Index(t => t.Nutrition_ID);
            
            CreateTable(
                "dbo.FoodFilters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ingredient = c.String(nullable: false),
                        Recipie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipie_Id, cascadeDelete: true)
                .Index(t => t.Recipie_Id);
            
            CreateTable(
                "dbo.MealTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MethodSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StepNo = c.Int(nullable: false),
                        Step = c.String(nullable: false),
                        Recipie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipie_Id, cascadeDelete: true)
                .Index(t => t.Recipie_Id);
            
            CreateTable(
                "dbo.Nutritions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Units = c.String(nullable: false),
                        EnergyKJ = c.Int(nullable: false),
                        EnergyKCal = c.Int(nullable: false),
                        Fat = c.Double(nullable: false),
                        Saturates = c.Double(nullable: false),
                        Carbohydrates = c.Double(nullable: false),
                        Sugars = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        Salt = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipesAllergens",
                c => new
                    {
                        Recipes_Id = c.Int(nullable: false),
                        Allergens_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipes_Id, t.Allergens_ID })
                .ForeignKey("dbo.Recipes", t => t.Recipes_Id, cascadeDelete: true)
                .ForeignKey("dbo.Allergens", t => t.Allergens_ID, cascadeDelete: true)
                .Index(t => t.Recipes_Id)
                .Index(t => t.Allergens_ID);
            
            CreateTable(
                "dbo.FoodFiltersRecipes",
                c => new
                    {
                        FoodFilters_ID = c.Int(nullable: false),
                        Recipes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FoodFilters_ID, t.Recipes_Id })
                .ForeignKey("dbo.FoodFilters", t => t.FoodFilters_ID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipes_Id, cascadeDelete: true)
                .Index(t => t.FoodFilters_ID)
                .Index(t => t.Recipes_Id);
            
            CreateTable(
                "dbo.MealTypesRecipes",
                c => new
                    {
                        MealTypes_ID = c.Int(nullable: false),
                        Recipes_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MealTypes_ID, t.Recipes_Id })
                .ForeignKey("dbo.MealTypes", t => t.MealTypes_ID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipes_Id, cascadeDelete: true)
                .Index(t => t.MealTypes_ID)
                .Index(t => t.Recipes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Nutrition_ID", "dbo.Nutritions");
            DropForeignKey("dbo.MethodSteps", "Recipie_Id", "dbo.Recipes");
            DropForeignKey("dbo.MealTypesRecipes", "Recipes_Id", "dbo.Recipes");
            DropForeignKey("dbo.MealTypesRecipes", "MealTypes_ID", "dbo.MealTypes");
            DropForeignKey("dbo.Ingredients", "Recipie_Id", "dbo.Recipes");
            DropForeignKey("dbo.FoodFiltersRecipes", "Recipes_Id", "dbo.Recipes");
            DropForeignKey("dbo.FoodFiltersRecipes", "FoodFilters_ID", "dbo.FoodFilters");
            DropForeignKey("dbo.RecipesAllergens", "Allergens_ID", "dbo.Allergens");
            DropForeignKey("dbo.RecipesAllergens", "Recipes_Id", "dbo.Recipes");
            DropIndex("dbo.MealTypesRecipes", new[] { "Recipes_Id" });
            DropIndex("dbo.MealTypesRecipes", new[] { "MealTypes_ID" });
            DropIndex("dbo.FoodFiltersRecipes", new[] { "Recipes_Id" });
            DropIndex("dbo.FoodFiltersRecipes", new[] { "FoodFilters_ID" });
            DropIndex("dbo.RecipesAllergens", new[] { "Allergens_ID" });
            DropIndex("dbo.RecipesAllergens", new[] { "Recipes_Id" });
            DropIndex("dbo.MethodSteps", new[] { "Recipie_Id" });
            DropIndex("dbo.Ingredients", new[] { "Recipie_Id" });
            DropIndex("dbo.Recipes", new[] { "Nutrition_ID" });
            DropTable("dbo.MealTypesRecipes");
            DropTable("dbo.FoodFiltersRecipes");
            DropTable("dbo.RecipesAllergens");
            DropTable("dbo.Nutritions");
            DropTable("dbo.MethodSteps");
            DropTable("dbo.MealTypes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.FoodFilters");
            DropTable("dbo.Recipes");
            DropTable("dbo.Allergens");
        }
    }
}
