namespace Fixie.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicUserInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "Forename", c => c.String());
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "Forename");
            DropColumn("dbo.Users", "Username");
        }
    }
}
