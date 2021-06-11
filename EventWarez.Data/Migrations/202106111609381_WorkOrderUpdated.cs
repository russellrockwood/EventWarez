namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkOrderUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrder", "Department", c => c.Int(nullable: false));
            DropColumn("dbo.Staff", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staff", "Department", c => c.Int(nullable: false));
            DropColumn("dbo.WorkOrder", "Department");
        }
    }
}
