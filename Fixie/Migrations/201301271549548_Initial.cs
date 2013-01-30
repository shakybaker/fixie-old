namespace Fixie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        Type = c.Int(nullable: false),
                        Priority_Id = c.Int(),
                        Complexity_Id = c.Int(),
                        SprintGoal_Id = c.Int(),
                        Lane_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriorityLevels", t => t.Priority_Id)
                .ForeignKey("dbo.ComplexityLevels", t => t.Complexity_Id)
                .ForeignKey("dbo.SprintGoals", t => t.SprintGoal_Id)
                .ForeignKey("dbo.Lanes", t => t.Lane_Id)
                .Index(t => t.Priority_Id)
                .Index(t => t.Complexity_Id)
                .Index(t => t.SprintGoal_Id)
                .Index(t => t.Lane_Id);
            
            CreateTable(
                "dbo.PriorityLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                        PriorityLevelTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriorityLevelTemplates", t => t.PriorityLevelTemplate_Id)
                .Index(t => t.PriorityLevelTemplate_Id);
            
            CreateTable(
                "dbo.ComplexityLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                        ComplexityLevelTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComplexityLevelTemplates", t => t.ComplexityLevelTemplate_Id)
                .Index(t => t.ComplexityLevelTemplate_Id);
            
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
                        Username = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        RememberMe = c.Boolean(nullable: false),
                        Gender = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        LaneTemplate_Id = c.Int(),
                        PriorityLevelTemplate_Id = c.Int(),
                        ComplexityLevelTemplate_Id = c.Int(),
                        Project_Id = c.Int(),
                        Release_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LaneTemplates", t => t.LaneTemplate_Id)
                .ForeignKey("dbo.PriorityLevelTemplates", t => t.PriorityLevelTemplate_Id)
                .ForeignKey("dbo.ComplexityLevelTemplates", t => t.ComplexityLevelTemplate_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Releases", t => t.Release_Id)
                .Index(t => t.LaneTemplate_Id)
                .Index(t => t.PriorityLevelTemplate_Id)
                .Index(t => t.ComplexityLevelTemplate_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.Release_Id);
            
            CreateTable(
                "dbo.Lanes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                        Board_Id = c.Int(),
                        LaneTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Board_Id)
                .ForeignKey("dbo.LaneTemplates", t => t.LaneTemplate_Id)
                .Index(t => t.Board_Id)
                .Index(t => t.LaneTemplate_Id);
            
            CreateTable(
                "dbo.LaneTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriorityLevelTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComplexityLevelTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Releases", new[] { "Project_Id" });
            DropIndex("dbo.Lanes", new[] { "LaneTemplate_Id" });
            DropIndex("dbo.Lanes", new[] { "Board_Id" });
            DropIndex("dbo.Boards", new[] { "Release_Id" });
            DropIndex("dbo.Boards", new[] { "Project_Id" });
            DropIndex("dbo.Boards", new[] { "ComplexityLevelTemplate_Id" });
            DropIndex("dbo.Boards", new[] { "PriorityLevelTemplate_Id" });
            DropIndex("dbo.Boards", new[] { "LaneTemplate_Id" });
            DropIndex("dbo.Tasks", new[] { "Card_Id" });
            DropIndex("dbo.Scenarios", new[] { "Card_Id" });
            DropIndex("dbo.Bugs", new[] { "Scenario_Id" });
            DropIndex("dbo.Bugs", new[] { "Card_Id" });
            DropIndex("dbo.Blockers", new[] { "Card_Id" });
            DropIndex("dbo.UserLinks", new[] { "Card_Id" });
            DropIndex("dbo.UserLinks", new[] { "User_Id" });
            DropIndex("dbo.ComplexityLevels", new[] { "ComplexityLevelTemplate_Id" });
            DropIndex("dbo.PriorityLevels", new[] { "PriorityLevelTemplate_Id" });
            DropIndex("dbo.Cards", new[] { "Lane_Id" });
            DropIndex("dbo.Cards", new[] { "SprintGoal_Id" });
            DropIndex("dbo.Cards", new[] { "Complexity_Id" });
            DropIndex("dbo.Cards", new[] { "Priority_Id" });
            DropForeignKey("dbo.Releases", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Lanes", "LaneTemplate_Id", "dbo.LaneTemplates");
            DropForeignKey("dbo.Lanes", "Board_Id", "dbo.Boards");
            DropForeignKey("dbo.Boards", "Release_Id", "dbo.Releases");
            DropForeignKey("dbo.Boards", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Boards", "ComplexityLevelTemplate_Id", "dbo.ComplexityLevelTemplates");
            DropForeignKey("dbo.Boards", "PriorityLevelTemplate_Id", "dbo.PriorityLevelTemplates");
            DropForeignKey("dbo.Boards", "LaneTemplate_Id", "dbo.LaneTemplates");
            DropForeignKey("dbo.Tasks", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Scenarios", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Bugs", "Scenario_Id", "dbo.Scenarios");
            DropForeignKey("dbo.Bugs", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Blockers", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.UserLinks", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.UserLinks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ComplexityLevels", "ComplexityLevelTemplate_Id", "dbo.ComplexityLevelTemplates");
            DropForeignKey("dbo.PriorityLevels", "PriorityLevelTemplate_Id", "dbo.PriorityLevelTemplates");
            DropForeignKey("dbo.Cards", "Lane_Id", "dbo.Lanes");
            DropForeignKey("dbo.Cards", "SprintGoal_Id", "dbo.SprintGoals");
            DropForeignKey("dbo.Cards", "Complexity_Id", "dbo.ComplexityLevels");
            DropForeignKey("dbo.Cards", "Priority_Id", "dbo.PriorityLevels");
            DropTable("dbo.Releases");
            DropTable("dbo.Projects");
            DropTable("dbo.ComplexityLevelTemplates");
            DropTable("dbo.PriorityLevelTemplates");
            DropTable("dbo.LaneTemplates");
            DropTable("dbo.Lanes");
            DropTable("dbo.Boards");
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
