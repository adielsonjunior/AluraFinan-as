namespace Financas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustedata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movimentacaos", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movimentacaos", "Data");
        }
    }
}
