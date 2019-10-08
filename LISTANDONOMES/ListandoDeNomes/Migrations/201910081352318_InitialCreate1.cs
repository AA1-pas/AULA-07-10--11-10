namespace ListandoDeNomes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NomePessoals", "Origem", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NomePessoals", "Origem", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
