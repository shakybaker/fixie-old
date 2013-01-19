namespace Fixie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoardSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "Name", c => c.String());
            AddColumn("dbo.Boards", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boards", "Description");
            DropColumn("dbo.Boards", "Name");
        }
    }
}
