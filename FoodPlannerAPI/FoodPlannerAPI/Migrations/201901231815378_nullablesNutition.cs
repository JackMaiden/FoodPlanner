namespace FoodPlannerAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablesNutition : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nutritions", "EnergyKJ", c => c.Int());
            AlterColumn("dbo.Nutritions", "EnergyKCal", c => c.Int());
            AlterColumn("dbo.Nutritions", "Fat", c => c.Double());
            AlterColumn("dbo.Nutritions", "Saturates", c => c.Double());
            AlterColumn("dbo.Nutritions", "Carbohydrates", c => c.Double());
            AlterColumn("dbo.Nutritions", "Sugars", c => c.Double());
            AlterColumn("dbo.Nutritions", "Protein", c => c.Double());
            AlterColumn("dbo.Nutritions", "Salt", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nutritions", "Salt", c => c.Double(nullable: false));
            AlterColumn("dbo.Nutritions", "Protein", c => c.Double(nullable: false));
            AlterColumn("dbo.Nutritions", "Sugars", c => c.Double(nullable: false));
            AlterColumn("dbo.Nutritions", "Carbohydrates", c => c.Double(nullable: false));
            AlterColumn("dbo.Nutritions", "Saturates", c => c.Double(nullable: false));
            AlterColumn("dbo.Nutritions", "Fat", c => c.Double(nullable: false));
            AlterColumn("dbo.Nutritions", "EnergyKCal", c => c.Int(nullable: false));
            AlterColumn("dbo.Nutritions", "EnergyKJ", c => c.Int(nullable: false));
        }
    }
}
