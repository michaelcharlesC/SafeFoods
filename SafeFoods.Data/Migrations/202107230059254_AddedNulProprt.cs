namespace SafeFoods.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNulProprt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngredientTag", "IngredientTypeId", "dbo.IngredientType");
            DropIndex("dbo.IngredientTag", new[] { "IngredientTypeId" });
            AlterColumn("dbo.IngredientTag", "IngredientTypeId", c => c.Int());
            CreateIndex("dbo.IngredientTag", "IngredientTypeId");
            AddForeignKey("dbo.IngredientTag", "IngredientTypeId", "dbo.IngredientType", "IngredientTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientTag", "IngredientTypeId", "dbo.IngredientType");
            DropIndex("dbo.IngredientTag", new[] { "IngredientTypeId" });
            AlterColumn("dbo.IngredientTag", "IngredientTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.IngredientTag", "IngredientTypeId");
            AddForeignKey("dbo.IngredientTag", "IngredientTypeId", "dbo.IngredientType", "IngredientTypeId", cascadeDelete: true);
        }
    }
}
