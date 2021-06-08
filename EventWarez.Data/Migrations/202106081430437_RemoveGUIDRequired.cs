namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGUIDRequired : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Show", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
