namespace MagazineSubscriptionApp.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Magazines", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.PublisherWorkers", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.Subscriptions", "Publisher_Id", "dbo.Publishers");
            DropIndex("dbo.Magazines", new[] { "Publisher_Id" });
            DropIndex("dbo.PublisherWorkers", new[] { "Publisher_Id" });
            DropIndex("dbo.Subscriptions", new[] { "Publisher_Id" });
            DropColumn("dbo.Magazines", "Publisher_Id");
            DropColumn("dbo.PublisherWorkers", "Publisher_Id");
            DropColumn("dbo.Subscriptions", "Publisher_Id");
            DropTable("dbo.Publishers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Subscriptions", "Publisher_Id", c => c.Guid());
            AddColumn("dbo.PublisherWorkers", "Publisher_Id", c => c.Guid());
            AddColumn("dbo.Magazines", "Publisher_Id", c => c.Guid());
            CreateIndex("dbo.Subscriptions", "Publisher_Id");
            CreateIndex("dbo.PublisherWorkers", "Publisher_Id");
            CreateIndex("dbo.Magazines", "Publisher_Id");
            AddForeignKey("dbo.Subscriptions", "Publisher_Id", "dbo.Publishers", "Id");
            AddForeignKey("dbo.PublisherWorkers", "Publisher_Id", "dbo.Publishers", "Id");
            AddForeignKey("dbo.Magazines", "Publisher_Id", "dbo.Publishers", "Id");
        }
    }
}
