namespace AllBusinesLands.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualiza7716 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bienes", "Estado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bienes", "Estado");
        }
    }
}
