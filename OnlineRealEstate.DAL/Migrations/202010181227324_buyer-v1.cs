namespace OnlineRealEstate.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buyerv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyerProperties",
                c => new
                    {
                        PropertyId = c.Int(nullable: false, identity: true),
                        PropertyTypeID = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Area = c.Int(nullable: false),
                        Image = c.Binary(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeID, cascadeDelete: true)
                .Index(t => t.PropertyTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyerProperties", "PropertyTypeID", "dbo.PropertyTypes");
            DropIndex("dbo.BuyerProperties", new[] { "PropertyTypeID" });
            DropTable("dbo.BuyerProperties");
        }
    }
}
