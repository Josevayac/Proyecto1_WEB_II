namespace AllBusinesLands.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Bienes_Comentarios_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bienes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Detalle = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                        Telefono = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        HoraIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BienId = c.Int(nullable: false),
                        Contenido = c.String(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        HoraIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bienes", t => t.BienId, cascadeDelete: true)
                .Index(t => t.BienId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "BienId", "dbo.Bienes");
            DropIndex("dbo.Comentarios", new[] { "BienId" });
            DropTable("dbo.Comentarios");
            DropTable("dbo.Bienes");
        }
    }
}
