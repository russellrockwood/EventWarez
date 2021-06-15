namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualFinalMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Show", "IsSoldOut");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "IsSoldOut", c => c.Boolean(nullable: false));
        }
    }
}
