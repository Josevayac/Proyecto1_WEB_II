namespace AllBusinesLands.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoTableBienesComentarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bienes", "Estado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comentarios", "Estado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comentarios", "Estado");
            DropColumn("dbo.Bienes", "Estado");
        }
    }
}
