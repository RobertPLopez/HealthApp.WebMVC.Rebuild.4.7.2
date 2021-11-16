namespace HealthApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Excersise",
                c => new
                    {
                        ExcersiseId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ExcersiseTypeId = c.Int(nullable: false),
                        PrimaryTableFitness_WorkoutId = c.Int(),
                    })
                .PrimaryKey(t => t.ExcersiseId)
                .ForeignKey("dbo.ExcersiseTypeTable", t => t.ExcersiseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PrimaryTableFitness", t => t.PrimaryTableFitness_WorkoutId)
                .Index(t => t.ExcersiseTypeId)
                .Index(t => t.PrimaryTableFitness_WorkoutId);
            
            CreateTable(
                "dbo.ExcersiseTypeTable",
                c => new
                    {
                        ExcersiseTypeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PreformedMovement = c.String(nullable: false),
                        ExcersiseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ExcersiseTypeId);
            
            CreateTable(
                "dbo.MuscleGroupTable",
                c => new
                    {
                        MuscleGroupTableId = c.Int(nullable: false, identity: true),
                        MuscleGroupWorkedName = c.String(nullable: false),
                        MuscleGroupWorkedNameId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        ExcersiseTypeTable_ExcersiseTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.MuscleGroupTableId)
                .ForeignKey("dbo.ExcersiseTypeTable", t => t.ExcersiseTypeTable_ExcersiseTypeId)
                .Index(t => t.ExcersiseTypeTable_ExcersiseTypeId);
            
            CreateTable(
                "dbo.SetsDataTable",
                c => new
                    {
                        SetId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RepsPerSet = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        DistanceRan = c.Int(nullable: false),
                        TimeRan = c.Int(nullable: false),
                        Excersise_ExcersiseId = c.Int(),
                    })
                .PrimaryKey(t => t.SetId)
                .ForeignKey("dbo.Excersise", t => t.Excersise_ExcersiseId)
                .Index(t => t.Excersise_ExcersiseId);
            
            CreateTable(
                "dbo.PrimaryTableFitness",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        TotalCaloriesBurned = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.WorkoutId);
            
            CreateTable(
                "dbo.PrimaryTableFood",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FoodName = c.String(nullable: false),
                        TotalCaloriesConsumed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FoodContent = c.String(nullable: false),
                        DailyWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CupsWaterDrank = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.FoodId);
            
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
                "dbo.PrimaryTableSpirit",
                c => new
                    {
                        HowIViewMe = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        HowIViewOthers = c.Int(nullable: false),
                        HowOtherPerceiveMe = c.Int(nullable: false),
                        MySocialCircle = c.String(nullable: false),
                        MyRestHours = c.Int(nullable: false),
                        OutsideMotivation = c.String(nullable: false),
                        InternalMotivaiton = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.HowIViewMe);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Excersise", "PrimaryTableFitness_WorkoutId", "dbo.PrimaryTableFitness");
            DropForeignKey("dbo.SetsDataTable", "Excersise_ExcersiseId", "dbo.Excersise");
            DropForeignKey("dbo.Excersise", "ExcersiseTypeId", "dbo.ExcersiseTypeTable");
            DropForeignKey("dbo.MuscleGroupTable", "ExcersiseTypeTable_ExcersiseTypeId", "dbo.ExcersiseTypeTable");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.SetsDataTable", new[] { "Excersise_ExcersiseId" });
            DropIndex("dbo.MuscleGroupTable", new[] { "ExcersiseTypeTable_ExcersiseTypeId" });
            DropIndex("dbo.Excersise", new[] { "PrimaryTableFitness_WorkoutId" });
            DropIndex("dbo.Excersise", new[] { "ExcersiseTypeId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.PrimaryTableSpirit");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PrimaryTableFood");
            DropTable("dbo.PrimaryTableFitness");
            DropTable("dbo.SetsDataTable");
            DropTable("dbo.MuscleGroupTable");
            DropTable("dbo.ExcersiseTypeTable");
            DropTable("dbo.Excersise");
        }
    }
}
