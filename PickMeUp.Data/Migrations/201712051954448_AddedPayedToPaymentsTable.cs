namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPayedToPaymentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Payed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Payed");
        }
    }
}
