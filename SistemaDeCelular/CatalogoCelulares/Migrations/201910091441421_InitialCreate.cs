namespace CatalogoCelulares.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Celulars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false, maxLength: 30),
                        Modelo = c.String(nullable: false, maxLength: 30),
                        Preco = c.Double(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuariCriacao = c.Int(nullable: false),
                        UsuarioAlterecao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Login = c.String(nullable: false, maxLength: 30),
                        Senha = c.String(nullable: false, maxLength: 30),
                        Ativo = c.Boolean(nullable: false),
                        UsuariCriacao = c.Int(nullable: false),
                        UsuarioAlterecao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Celulars");
        }
    }
}
