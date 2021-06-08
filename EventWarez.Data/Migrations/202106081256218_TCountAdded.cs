namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TCountAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ticket", "TCount", c => c.Int(nullable: false));
            DropColumn("dbo.Attendee", "AccessLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendee", "AccessLevel", c => c.String(nullable: false));
            DropColumn("dbo.Ticket", "TCount");
        }
    }
}
