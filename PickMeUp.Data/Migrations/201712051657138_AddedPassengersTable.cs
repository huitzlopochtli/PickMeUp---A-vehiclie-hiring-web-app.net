namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPassengersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        WalletBalance = c.Single(nullable: false),
                        TotalRides = c.Int(nullable: false),
                        RewordPoint = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "UserId", "dbo.Users");
            DropIndex("dbo.Passengers", new[] { "UserId" });
            DropTable("dbo.Passengers");
        }
    }
}
