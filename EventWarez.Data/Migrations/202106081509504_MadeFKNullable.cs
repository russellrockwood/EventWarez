namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeFKNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "AttId", "dbo.Attendee");
            DropIndex("dbo.Ticket", new[] { "AttId" });
            AlterColumn("dbo.Ticket", "AttId", c => c.Int());
            CreateIndex("dbo.Ticket", "AttId");
            AddForeignKey("dbo.Ticket", "AttId", "dbo.Attendee", "AttId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "AttId", "dbo.Attendee");
            DropIndex("dbo.Ticket", new[] { "AttId" });
            AlterColumn("dbo.Ticket", "AttId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "AttId");
            AddForeignKey("dbo.Ticket", "AttId", "dbo.Attendee", "AttId", cascadeDelete: true);
        }
    }
}
