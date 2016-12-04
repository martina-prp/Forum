namespace SiteSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum_Name : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Fora", newName: "MyForums");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MyForums", newName: "Fora");
        }
    }
}
