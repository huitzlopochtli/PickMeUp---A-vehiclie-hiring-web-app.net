namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaymentTypestoPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaymentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "PaymentTypeId");
            AddForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.Payments", new[] { "PaymentTypeId" });
            DropColumn("dbo.Payments", "PaymentTypeId");
        }
    }
}
