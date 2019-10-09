namespace CatalogoCelulares.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allan3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Celulars", "Camera");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Celulars", "Camera", c => c.Boolean(nullable: false));
        }
    }
}
