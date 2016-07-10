namespace AllBusinesLands.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_user_comentarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comentarios", "UserId", c => c.String(nullable: false));
            AddColumn("dbo.Comentarios", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comentarios", "ApplicationUser_Id");
            AddForeignKey("dbo.Comentarios", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comentarios", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Comentarios", "ApplicationUser_Id");
            DropColumn("dbo.Comentarios", "UserId");
        }
    }
}
