namespace Fixie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLaneTemplate : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Boards", "LaneTemplate_Id", c => c.Int());
            AddColumn("dbo.Lanes", "LaneTemplate_Id", c => c.Int());
            AddForeignKey("dbo.Boards", "LaneTemplate_Id", "dbo.LaneTemplates", "Id");
            AddForeignKey("dbo.Lanes", "LaneTemplate_Id", "dbo.LaneTemplates", "Id");
            CreateIndex("dbo.Boards", "LaneTemplate_Id");
            CreateIndex("dbo.Lanes", "LaneTemplate_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Lanes", new[] { "LaneTemplate_Id" });
            DropIndex("dbo.Boards", new[] { "LaneTemplate_Id" });
            DropForeignKey("dbo.Lanes", "LaneTemplate_Id", "dbo.LaneTemplates");
            DropForeignKey("dbo.Boards", "LaneTemplate_Id", "dbo.LaneTemplates");
            DropColumn("dbo.Lanes", "LaneTemplate_Id");
            DropColumn("dbo.Boards", "LaneTemplate_Id");
            DropTable("dbo.LaneTemplates");
        }
    }
}
