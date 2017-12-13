namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehicleTypesToRide : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rides", "VehicleTypeId", c => c.Int());
            CreateIndex("dbo.Rides", "VehicleTypeId");
            AddForeignKey("dbo.Rides", "VehicleTypeId", "dbo.VehicleTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rides", "VehicleTypeId", "dbo.VehicleTypes");
            DropIndex("dbo.Rides", new[] { "VehicleTypeId" });
            DropColumn("dbo.Rides", "VehicleTypeId");
        }
    }
}
