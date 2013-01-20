namespace Fixie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "Forename");
            DropColumn("dbo.Users", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "Forename", c => c.String());
            DropColumn("dbo.Users", "Name");
        }
    }
}
