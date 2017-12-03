namespace PickMeUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Discriminator");
        }
    }
}
