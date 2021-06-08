namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIdToTicketId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Ticket");
            DropColumn("dbo.Ticket", "Id");
            AddColumn("dbo.Ticket", "TicketId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Ticket", "TicketId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Ticket");
            DropColumn("dbo.Ticket", "TicketId");
            AddPrimaryKey("dbo.Ticket", "Id");
        }
    }
}
