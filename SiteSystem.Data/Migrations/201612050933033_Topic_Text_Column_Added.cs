namespace SiteSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Topic_Text_Column_Added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Comments", new[] { "Topic_Id" });
            DropIndex("dbo.Comments", new[] { "Forum_Id" });
            AddColumn("dbo.Topics", "TopicText", c => c.String());
            AlterColumn("dbo.Comments", "Topic_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Topic_Id");
            AddForeignKey("dbo.Comments", "Topic_Id", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Forum_Id", c => c.Int());
            DropForeignKey("dbo.Comments", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Comments", new[] { "Topic_Id" });
            AlterColumn("dbo.Comments", "Topic_Id", c => c.Int());
            DropColumn("dbo.Topics", "TopicText");
            CreateIndex("dbo.Comments", "Forum_Id");
            CreateIndex("dbo.Comments", "Topic_Id");
            AddForeignKey("dbo.Comments", "Topic_Id", "dbo.Topics", "Id");
            AddForeignKey("dbo.Comments", "Forum_Id", "dbo.SiteForums", "Id");
        }
    }
}
