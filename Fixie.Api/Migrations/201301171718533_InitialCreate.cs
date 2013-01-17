namespace Fixie.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Priority_Id = c.Int(),
                        Complexity_Id = c.Int(),
                        SprintGoal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriorityLevels", t => t.Priority_Id)
                .ForeignKey("dbo.ComplexityLevels", t => t.Complexity_Id)
                .ForeignKey("dbo.SprintGoals", t => t.SprintGoal_Id)
                .Index(t => t.Priority_Id)
                .Index(t => t.Complexity_Id)
                .Index(t => t.SprintGoal_Id);
            
            CreateTable(
                "dbo.PriorityLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComplexityLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        LinkType = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blockers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Bugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Description = c.String(),
                        Card_Id = c.Int(),
                        Scenario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .ForeignKey("dbo.Scenarios", t => t.Scenario_Id)
                .Index(t => t.Card_Id)
                .Index(t => t.Scenario_Id);
            
            CreateTable(
                "dbo.Scenarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Description = c.String(),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.SprintGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        GoalMet = c.Boolean(nullable: false),
                        WhyNotMet = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tasks", new[] { "Card_Id" });
            DropIndex("dbo.Scenarios", new[] { "Card_Id" });
            DropIndex("dbo.Bugs", new[] { "Scenario_Id" });
            DropIndex("dbo.Bugs", new[] { "Card_Id" });
            DropIndex("dbo.Blockers", new[] { "Card_Id" });
            DropIndex("dbo.UserLinks", new[] { "Card_Id" });
            DropIndex("dbo.UserLinks", new[] { "User_Id" });
            DropIndex("dbo.Cards", new[] { "SprintGoal_Id" });
            DropIndex("dbo.Cards", new[] { "Complexity_Id" });
            DropIndex("dbo.Cards", new[] { "Priority_Id" });
            DropForeignKey("dbo.Tasks", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Scenarios", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Bugs", "Scenario_Id", "dbo.Scenarios");
            DropForeignKey("dbo.Bugs", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Blockers", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.UserLinks", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.UserLinks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Cards", "SprintGoal_Id", "dbo.SprintGoals");
            DropForeignKey("dbo.Cards", "Complexity_Id", "dbo.ComplexityLevels");
            DropForeignKey("dbo.Cards", "Priority_Id", "dbo.PriorityLevels");
            DropTable("dbo.SprintGoals");
            DropTable("dbo.Tasks");
            DropTable("dbo.Scenarios");
            DropTable("dbo.Bugs");
            DropTable("dbo.Blockers");
            DropTable("dbo.Users");
            DropTable("dbo.UserLinks");
            DropTable("dbo.ComplexityLevels");
            DropTable("dbo.PriorityLevels");
            DropTable("dbo.Cards");
        }
    }
}
