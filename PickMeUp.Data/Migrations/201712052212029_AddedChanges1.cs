namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChanges1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PassengerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "PassengerId");
            AddForeignKey("dbo.Payments", "PassengerId", "dbo.Passengers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PassengerId", "dbo.Passengers");
            DropIndex("dbo.Payments", new[] { "PassengerId" });
            DropColumn("dbo.Payments", "PassengerId");
        }
    }
}
