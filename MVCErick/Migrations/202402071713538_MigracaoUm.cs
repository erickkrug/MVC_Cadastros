namespace MVCErick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoUm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpresaModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeEmpresa = c.String(nullable: false, maxLength: 100),
                        DescricaoEmpresa = c.String(),
                        Localidade = c.String(maxLength: 100),
                        CNPJ = c.String(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UsuarioModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(),
                        CPF = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(maxLength: 20),
                        EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmpresaModels", t => t.EmpresaId, cascadeDelete: true)
                .Index(t => t.EmpresaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioModels", "EmpresaId", "dbo.EmpresaModels");
            DropIndex("dbo.UsuarioModels", new[] { "EmpresaId" });
            DropTable("dbo.UsuarioModels");
            DropTable("dbo.EmpresaModels");
        }
    }
}
