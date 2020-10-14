namespace OnlineRealEstate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Properties", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Properties", "ImagePath", c => c.String());
        }
    }
}
