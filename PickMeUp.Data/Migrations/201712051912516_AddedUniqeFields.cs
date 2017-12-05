namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUniqeFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drivers", "DrivingLicence", c => c.String(maxLength: 200));
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String(maxLength: 200));
            AlterColumn("dbo.VehicleTypes", "Name", c => c.String(maxLength: 200));
            CreateIndex("dbo.Drivers", "DrivingLicence", unique: true);
            CreateIndex("dbo.Vehicles", "RegNumber", unique: true);
            CreateIndex("dbo.VehicleTypes", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.VehicleTypes", new[] { "Name" });
            DropIndex("dbo.Vehicles", new[] { "RegNumber" });
            DropIndex("dbo.Drivers", new[] { "DrivingLicence" });
            AlterColumn("dbo.VehicleTypes", "Name", c => c.String());
            AlterColumn("dbo.Vehicles", "RegNumber", c => c.String());
            AlterColumn("dbo.Drivers", "DrivingLicence", c => c.String());
        }
    }
}
