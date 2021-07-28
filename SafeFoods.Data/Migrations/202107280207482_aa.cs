namespace SafeFoods.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientTag",
                c => new
                    {
                        IngredientTagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        OwnerId = c.Guid(nullable: false),
                        DateAdded = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                        IngredientTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientTagId)
                .ForeignKey("dbo.IngredientType", t => t.IngredientTypeId)
                .Index(t => t.IngredientTypeId);
            
            CreateTable(
                "dbo.IngredientType",
                c => new
                    {
                        IngredientTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientTypeId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 100),
                        Instructions = c.String(nullable: false, maxLength: 2000),
                        PrepTime = c.Time(nullable: false, precision: 7),
                        CookTime = c.Int(nullable: false),
                        DateAdded = c.DateTimeOffset(nullable: false, precision: 7),
                        DateModified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.Nutrition",
                c => new
                    {
                        RecipeID = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Carbohydrates = c.Int(),
                        Calories = c.Int(),
                        FatGram = c.Int(),
                        Protein = c.Int(),
                        Fiber = c.Int(),
                    })
                .PrimaryKey(t => t.RecipeID)
                .ForeignKey("dbo.Recipe", t => t.RecipeID)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.RecipeIngredientTag",
                c => new
                    {
                        Recipe_RecipeId = c.Int(nullable: false),
                        IngredientTag_IngredientTagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeId, t.IngredientTag_IngredientTagId })
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.IngredientTag", t => t.IngredientTag_IngredientTagId, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.IngredientTag_IngredientTagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Nutrition", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIngredientTag", "IngredientTag_IngredientTagId", "dbo.IngredientTag");
            DropForeignKey("dbo.RecipeIngredientTag", "Recipe_RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.IngredientTag", "IngredientTypeId", "dbo.IngredientType");
            DropIndex("dbo.RecipeIngredientTag", new[] { "IngredientTag_IngredientTagId" });
            DropIndex("dbo.RecipeIngredientTag", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Nutrition", new[] { "RecipeID" });
            DropIndex("dbo.IngredientTag", new[] { "IngredientTypeId" });
            DropTable("dbo.RecipeIngredientTag");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Nutrition");
            DropTable("dbo.Recipe");
            DropTable("dbo.IngredientType");
            DropTable("dbo.IngredientTag");
        }
    }
}
