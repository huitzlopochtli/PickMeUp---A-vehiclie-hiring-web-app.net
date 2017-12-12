namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDriverToNullToRide : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rides", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Rides", new[] { "DriverId" });
            AlterColumn("dbo.Rides", "DriverId", c => c.Int());
            CreateIndex("dbo.Rides", "DriverId");
            AddForeignKey("dbo.Rides", "DriverId", "dbo.Drivers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rides", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Rides", new[] { "DriverId" });
            AlterColumn("dbo.Rides", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rides", "DriverId");
            AddForeignKey("dbo.Rides", "DriverId", "dbo.Drivers", "Id", cascadeDelete: true);
        }
    }
}
