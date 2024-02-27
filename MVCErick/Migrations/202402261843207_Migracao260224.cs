namespace MVCErick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracao260224 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmpresaModels", "EnderecoEmpresa", c => c.String(maxLength: 100));
            DropColumn("dbo.EmpresaModels", "Localidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmpresaModels", "Localidade", c => c.String(maxLength: 100));
            DropColumn("dbo.EmpresaModels", "EnderecoEmpresa");
        }
    }
}
