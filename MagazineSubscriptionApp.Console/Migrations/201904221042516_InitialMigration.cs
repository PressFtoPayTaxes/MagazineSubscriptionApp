namespace MagazineSubscriptionApp.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Account_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        Cost = c.Int(nullable: false),
                        Publisher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublisherWorkers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        IsDirector = c.Boolean(nullable: false),
                        Account_Id = c.Guid(),
                        Publisher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        SubscriptionTerm = c.Int(nullable: false),
                        Client_Id = c.Guid(),
                        Publisher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Publisher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.Subscriptions", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.PublisherWorkers", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.PublisherWorkers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Magazines", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.Clients", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Subscriptions", new[] { "Publisher_Id" });
            DropIndex("dbo.Subscriptions", new[] { "Client_Id" });
            DropIndex("dbo.PublisherWorkers", new[] { "Publisher_Id" });
            DropIndex("dbo.PublisherWorkers", new[] { "Account_Id" });
            DropIndex("dbo.Magazines", new[] { "Publisher_Id" });
            DropIndex("dbo.Clients", new[] { "Account_Id" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.PublisherWorkers");
            DropTable("dbo.Publishers");
            DropTable("dbo.Magazines");
            DropTable("dbo.Clients");
            DropTable("dbo.Accounts");
        }
    }
}
