namespace Angular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary());
            DropColumn("dbo.Products", "UrlImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UrlImage", c => c.String());
            DropColumn("dbo.Products", "Image");
        }
    }
}
