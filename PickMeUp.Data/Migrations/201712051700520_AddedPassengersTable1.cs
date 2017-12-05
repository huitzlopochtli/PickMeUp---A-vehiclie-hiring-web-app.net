namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPassengersTable1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Passengers");
            AlterColumn("dbo.Passengers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Passengers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Passengers");
            AlterColumn("dbo.Passengers", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Passengers", "Id");
        }
    }
}
