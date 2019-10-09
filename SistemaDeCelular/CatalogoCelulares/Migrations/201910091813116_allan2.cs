namespace CatalogoCelulares.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allan2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Celulars", "Camera", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Celulars", "Camera");
        }
    }
}
