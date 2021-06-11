namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSoldOut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "IsSoldOut", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Show", "IsSoldOut");
        }
    }
}
