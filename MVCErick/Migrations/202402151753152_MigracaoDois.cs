namespace MVCErick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoDois : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioModels", "EmpresaId", "dbo.EmpresaModels");
            DropIndex("dbo.UsuarioModels", new[] { "EmpresaId" });
            RenameColumn(table: "dbo.UsuarioModels", name: "EmpresaId", newName: "Empresa_ID");
            AlterColumn("dbo.UsuarioModels", "Empresa_ID", c => c.Int());
            CreateIndex("dbo.UsuarioModels", "Empresa_ID");
            AddForeignKey("dbo.UsuarioModels", "Empresa_ID", "dbo.EmpresaModels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioModels", "Empresa_ID", "dbo.EmpresaModels");
            DropIndex("dbo.UsuarioModels", new[] { "Empresa_ID" });
            AlterColumn("dbo.UsuarioModels", "Empresa_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.UsuarioModels", name: "Empresa_ID", newName: "EmpresaId");
            CreateIndex("dbo.UsuarioModels", "EmpresaId");
            AddForeignKey("dbo.UsuarioModels", "EmpresaId", "dbo.EmpresaModels", "ID", cascadeDelete: true);
        }
    }
}
