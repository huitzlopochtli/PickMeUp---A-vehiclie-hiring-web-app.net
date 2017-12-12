namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimeToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rides", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Rides", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rides", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rides", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
