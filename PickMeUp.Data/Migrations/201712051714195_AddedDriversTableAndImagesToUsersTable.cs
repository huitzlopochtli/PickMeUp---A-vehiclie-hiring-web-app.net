namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDriversTableAndImagesToUsersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrivingLicence = c.String(),
                        DrivingLicenceImage = c.Binary(),
                        UserId = c.String(maxLength: 128),
                        Earnings = c.Single(nullable: false),
                        TotalRides = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "Image", c => c.Binary());
            AlterColumn("dbo.Users", "Fullname", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "UserId", "dbo.Users");
            DropIndex("dbo.Drivers", new[] { "UserId" });
            AlterColumn("dbo.Users", "Fullname", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Image");
            DropTable("dbo.Drivers");
        }
    }
}
