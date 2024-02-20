namespace MVCErick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioModels", "Empresa_ID", "dbo.EmpresaModels");
            DropIndex("dbo.UsuarioModels", new[] { "Empresa_ID" });
            RenameColumn(table: "dbo.UsuarioModels", name: "Empresa_ID", newName: "EmpresaId");
            AlterColumn("dbo.UsuarioModels", "EmpresaId", c => c.Int(nullable: false));
            CreateIndex("dbo.UsuarioModels", "EmpresaId");
            AddForeignKey("dbo.UsuarioModels", "EmpresaId", "dbo.EmpresaModels", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioModels", "EmpresaId", "dbo.EmpresaModels");
            DropIndex("dbo.UsuarioModels", new[] { "EmpresaId" });
            AlterColumn("dbo.UsuarioModels", "EmpresaId", c => c.Int());
            RenameColumn(table: "dbo.UsuarioModels", name: "EmpresaId", newName: "Empresa_ID");
            CreateIndex("dbo.UsuarioModels", "Empresa_ID");
            AddForeignKey("dbo.UsuarioModels", "Empresa_ID", "dbo.EmpresaModels", "ID");
        }
    }
}
