namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "ShowId", "dbo.Show");
            DropForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff");
            DropIndex("dbo.Ticket", new[] { "ShowId" });
            DropIndex("dbo.WorkOrder", new[] { "StaffId" });
            AlterColumn("dbo.Ticket", "ShowId", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkOrder", "StaffId", c => c.Int());
            CreateIndex("dbo.Ticket", "ShowId");
            CreateIndex("dbo.WorkOrder", "StaffId");
            AddForeignKey("dbo.Ticket", "ShowId", "dbo.Show", "ShowId", cascadeDelete: true);
            AddForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff", "StaffId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.Ticket", "ShowId", "dbo.Show");
            DropIndex("dbo.WorkOrder", new[] { "StaffId" });
            DropIndex("dbo.Ticket", new[] { "ShowId" });
            AlterColumn("dbo.WorkOrder", "StaffId", c => c.Int(nullable: false));
            AlterColumn("dbo.Ticket", "ShowId", c => c.Int());
            CreateIndex("dbo.WorkOrder", "StaffId");
            CreateIndex("dbo.Ticket", "ShowId");
            AddForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff", "StaffId", cascadeDelete: true);
            AddForeignKey("dbo.Ticket", "ShowId", "dbo.Show", "ShowId");
        }
    }
}
