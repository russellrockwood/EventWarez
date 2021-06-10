namespace EventWarez.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Attendee",
            //    c => new
            //        {
            //            AttId = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(nullable: false),
            //            LastName = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.AttId);
            
            //CreateTable(
            //    "dbo.Ticket",
            //    c => new
            //        {
            //            TicketId = c.Int(nullable: false, identity: true),
            //            ShowId = c.Int(),
            //            AttId = c.Int(),
            //            Price = c.Int(nullable: false),
            //            TypeOfTicket = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.TicketId)
            //    .ForeignKey("dbo.Attendee", t => t.AttId)
            //    .ForeignKey("dbo.Show", t => t.ShowId)
            //    .Index(t => t.ShowId)
            //    .Index(t => t.AttId);
            
            //CreateTable(
            //    "dbo.Show",
            //    c => new
            //        {
            //            ShowId = c.Int(nullable: false, identity: true),
            //            Feature = c.String(nullable: false),
            //            ShowTime = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ShowId);
            
            CreateTable(
                "dbo.WorkOrder",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        StaffId = c.Int(nullable: false),
                        ShowId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.WorkOrderId)
                .ForeignKey("dbo.Show", t => t.ShowId, cascadeDelete: true)
                .ForeignKey("dbo.Staff", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.ShowId);
            
            //CreateTable(
            //    "dbo.Staff",
            //    c => new
            //        {
            //            StaffId = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(nullable: false),
            //            LastName = c.String(nullable: false),
            //            Department = c.Int(nullable: false),
            //            AccessLevel = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.StaffId);
            
            //CreateTable(
            //    "dbo.IdentityRole",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.IdentityUserRole",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(),
            //            IdentityRole_Id = c.String(maxLength: 128),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.UserId)
            //    .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
            //    .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            //    .Index(t => t.IdentityRole_Id)
            //    .Index(t => t.ApplicationUser_Id);
            
            //CreateTable(
            //    "dbo.ApplicationUser",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.IdentityUserClaim",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            //    .Index(t => t.ApplicationUser_Id);
            
            //CreateTable(
            //    "dbo.IdentityUserLogin",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            LoginProvider = c.String(),
            //            ProviderKey = c.String(),
            //            ApplicationUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.UserId)
            //    .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
            //    .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.WorkOrder", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.WorkOrder", "ShowId", "dbo.Show");
            DropForeignKey("dbo.Ticket", "ShowId", "dbo.Show");
            DropForeignKey("dbo.Ticket", "AttId", "dbo.Attendee");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.WorkOrder", new[] { "ShowId" });
            DropIndex("dbo.WorkOrder", new[] { "StaffId" });
            DropIndex("dbo.Ticket", new[] { "AttId" });
            DropIndex("dbo.Ticket", new[] { "ShowId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Staff");
            DropTable("dbo.WorkOrder");
            DropTable("dbo.Show");
            DropTable("dbo.Ticket");
            DropTable("dbo.Attendee");
        }
    }
}
