namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRidesPaymentsandPaymentTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(nullable: false),
                        PassengerId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        StartLocation = c.String(),
                        EndLocation = c.String(),
                        PaymentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Passengers", t => t.PassengerId, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.PassengerId)
                .Index(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rides", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Rides", "PassengerId", "dbo.Passengers");
            DropForeignKey("dbo.Rides", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Rides", new[] { "PaymentId" });
            DropIndex("dbo.Rides", new[] { "PassengerId" });
            DropIndex("dbo.Rides", new[] { "DriverId" });
            DropTable("dbo.Rides");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Payments");
        }
    }
}
