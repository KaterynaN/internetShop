namespace InternetShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.items", "image_url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.items", "image_url");
        }
    }
}
