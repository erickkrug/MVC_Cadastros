namespace MVCErick.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTiposTabela : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmpresaModels", "CNPJ", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmpresaModels", "CNPJ", c => c.Int(nullable: false));
        }
    }
}
