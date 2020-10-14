namespace OnlineRealEstate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "Image");
        }
    }
}
