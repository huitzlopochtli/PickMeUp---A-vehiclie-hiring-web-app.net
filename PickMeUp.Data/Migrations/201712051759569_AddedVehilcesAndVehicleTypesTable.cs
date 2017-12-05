namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVehilcesAndVehicleTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        CompanyName = c.String(),
                        Color = c.String(),
                        RegNumber = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FareRate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "VehicleId" });
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
        }
    }
}
