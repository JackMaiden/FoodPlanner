namespace FoodPlannerAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedSpelling : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Recipies", newName: "Recipes");
            RenameTable(name: "dbo.RecipiesAllergens", newName: "RecipesAllergens");
            RenameTable(name: "dbo.FoodFiltersRecipies", newName: "FoodFiltersRecipes");
            RenameTable(name: "dbo.MealTypesRecipies", newName: "MealTypesRecipes");
            RenameColumn(table: "dbo.RecipesAllergens", name: "Recipies_Id", newName: "Recipes_Id");
            RenameColumn(table: "dbo.FoodFiltersRecipes", name: "Recipies_Id", newName: "Recipes_Id");
            RenameColumn(table: "dbo.Ingredients", name: "Recipie_Id", newName: "Recipe_Id");
            RenameColumn(table: "dbo.MealTypesRecipes", name: "Recipies_Id", newName: "Recipes_Id");
            RenameIndex(table: "dbo.Ingredients", name: "IX_Recipie_Id", newName: "IX_Recipe_Id");
            RenameIndex(table: "dbo.RecipesAllergens", name: "IX_Recipies_Id", newName: "IX_Recipes_Id");
            RenameIndex(table: "dbo.FoodFiltersRecipes", name: "IX_Recipies_Id", newName: "IX_Recipes_Id");
            RenameIndex(table: "dbo.MealTypesRecipes", name: "IX_Recipies_Id", newName: "IX_Recipes_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MealTypesRecipes", name: "IX_Recipes_Id", newName: "IX_Recipies_Id");
            RenameIndex(table: "dbo.FoodFiltersRecipes", name: "IX_Recipes_Id", newName: "IX_Recipies_Id");
            RenameIndex(table: "dbo.RecipesAllergens", name: "IX_Recipes_Id", newName: "IX_Recipies_Id");
            RenameIndex(table: "dbo.Ingredients", name: "IX_Recipe_Id", newName: "IX_Recipie_Id");
            RenameColumn(table: "dbo.MealTypesRecipes", name: "Recipes_Id", newName: "Recipies_Id");
            RenameColumn(table: "dbo.Ingredients", name: "Recipe_Id", newName: "Recipie_Id");
            RenameColumn(table: "dbo.FoodFiltersRecipes", name: "Recipes_Id", newName: "Recipies_Id");
            RenameColumn(table: "dbo.RecipesAllergens", name: "Recipes_Id", newName: "Recipies_Id");
            RenameTable(name: "dbo.MealTypesRecipes", newName: "MealTypesRecipies");
            RenameTable(name: "dbo.FoodFiltersRecipes", newName: "FoodFiltersRecipies");
            RenameTable(name: "dbo.RecipesAllergens", newName: "RecipiesAllergens");
            RenameTable(name: "dbo.Recipes", newName: "Recipies");
        }
    }
}
