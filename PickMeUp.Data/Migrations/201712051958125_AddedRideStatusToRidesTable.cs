namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRideStatusToRidesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rides", "RideStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rides", "RideStatus");
        }
    }
}
