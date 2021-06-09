namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddedShowIdToTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "ShowId", "dbo.Show");
            DropIndex("dbo.Ticket", new[] { "ShowId" });
            AlterColumn("dbo.Ticket", "ShowId", c => c.Int());
            CreateIndex("dbo.Ticket", "ShowId");
            AddForeignKey("dbo.Ticket", "ShowId", "dbo.Show", "ShowId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "ShowId", "dbo.Show");
            DropIndex("dbo.Ticket", new[] { "ShowId" });
            AlterColumn("dbo.Ticket", "ShowId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "ShowId");
            AddForeignKey("dbo.Ticket", "ShowId", "dbo.Show", "ShowId", cascadeDelete: true);
        }
    }
}
