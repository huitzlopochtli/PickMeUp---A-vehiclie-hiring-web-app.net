namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusToDrivesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Status");
        }
    }
}
