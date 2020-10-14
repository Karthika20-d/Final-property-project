namespace OnlineRealEstate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userv1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Properties", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "UserId");
            DropColumn("dbo.Properties", "UserId");
            AddPrimaryKey("dbo.Users", "Name");
        }
    }
}
