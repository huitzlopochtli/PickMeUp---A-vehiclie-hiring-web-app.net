namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDriversTableAndImagesToUsersTable1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "DrivingLicenceImage");
            DropColumn("dbo.Users", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Image", c => c.Binary());
            AddColumn("dbo.Drivers", "DrivingLicenceImage", c => c.Binary());
        }
    }
}
