namespace Fixie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeepInSync : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        Modified = c.DateTime(),
                        ModifiedBy = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        PriorityLevelTemplate_Id = c.Int(),
                        ComplexityLevelTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriorityLevelTemplates", t => t.PriorityLevelTemplate_Id)
                .ForeignKey("dbo.ComplexityLevelTemplates", t => t.ComplexityLevelTemplate_Id)
                .Index(t => t.PriorityLevelTemplate_Id)
                .Index(t => t.ComplexityLevelTemplate_Id);
            
            CreateTable(
                "dbo.Lanes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                        Board_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boards", t => t.Board_Id)
                .Index(t => t.Board_Id);
            
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
            
            AddColumn("dbo.Cards", "Lane_Id", c => c.Int());
            AddColumn("dbo.PriorityLevels", "PriorityLevelTemplate_Id", c => c.Int());
            AddColumn("dbo.ComplexityLevels", "ComplexityLevelTemplate_Id", c => c.Int());
            AddForeignKey("dbo.Cards", "Lane_Id", "dbo.Lanes", "Id");
            AddForeignKey("dbo.PriorityLevels", "PriorityLevelTemplate_Id", "dbo.PriorityLevelTemplates", "Id");
            AddForeignKey("dbo.ComplexityLevels", "ComplexityLevelTemplate_Id", "dbo.ComplexityLevelTemplates", "Id");
            CreateIndex("dbo.Cards", "Lane_Id");
            CreateIndex("dbo.PriorityLevels", "PriorityLevelTemplate_Id");
            CreateIndex("dbo.ComplexityLevels", "ComplexityLevelTemplate_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Lanes", new[] { "Board_Id" });
            DropIndex("dbo.Boards", new[] { "ComplexityLevelTemplate_Id" });
            DropIndex("dbo.Boards", new[] { "PriorityLevelTemplate_Id" });
            DropIndex("dbo.ComplexityLevels", new[] { "ComplexityLevelTemplate_Id" });
            DropIndex("dbo.PriorityLevels", new[] { "PriorityLevelTemplate_Id" });
            DropIndex("dbo.Cards", new[] { "Lane_Id" });
            DropForeignKey("dbo.Lanes", "Board_Id", "dbo.Boards");
            DropForeignKey("dbo.Boards", "ComplexityLevelTemplate_Id", "dbo.ComplexityLevelTemplates");
            DropForeignKey("dbo.Boards", "PriorityLevelTemplate_Id", "dbo.PriorityLevelTemplates");
            DropForeignKey("dbo.ComplexityLevels", "ComplexityLevelTemplate_Id", "dbo.ComplexityLevelTemplates");
            DropForeignKey("dbo.PriorityLevels", "PriorityLevelTemplate_Id", "dbo.PriorityLevelTemplates");
            DropForeignKey("dbo.Cards", "Lane_Id", "dbo.Lanes");
            DropColumn("dbo.ComplexityLevels", "ComplexityLevelTemplate_Id");
            DropColumn("dbo.PriorityLevels", "PriorityLevelTemplate_Id");
            DropColumn("dbo.Cards", "Lane_Id");
            DropTable("dbo.ComplexityLevelTemplates");
            DropTable("dbo.PriorityLevelTemplates");
            DropTable("dbo.Lanes");
            DropTable("dbo.Boards");
        }
    }
}
