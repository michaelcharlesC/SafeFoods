namespace SafeFoods.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMgration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipe", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipe", "Rating", c => c.Int());
        }
    }
}
