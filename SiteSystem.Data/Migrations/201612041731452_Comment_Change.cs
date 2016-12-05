namespace SiteSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comment_Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "Forum_Id", "dbo.SiteForums");
            DropIndex("dbo.Topics", new[] { "Forum_Id" });
            AlterColumn("dbo.Topics", "Forum_Id", c => c.Int());
            CreateIndex("dbo.Topics", "Forum_Id");
            AddForeignKey("dbo.Topics", "Forum_Id", "dbo.SiteForums", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Forum_Id", "dbo.SiteForums");
            DropIndex("dbo.Topics", new[] { "Forum_Id" });
            AlterColumn("dbo.Topics", "Forum_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Topics", "Forum_Id");
            AddForeignKey("dbo.Topics", "Forum_Id", "dbo.SiteForums", "Id", cascadeDelete: true);
        }
    }
}
