namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Vehicles", name: "VehicleId", newName: "VehicleTypeId");
            RenameIndex(table: "dbo.Vehicles", name: "IX_VehicleId", newName: "IX_VehicleTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vehicles", name: "IX_VehicleTypeId", newName: "IX_VehicleId");
            RenameColumn(table: "dbo.Vehicles", name: "VehicleTypeId", newName: "VehicleId");
        }
    }
}
