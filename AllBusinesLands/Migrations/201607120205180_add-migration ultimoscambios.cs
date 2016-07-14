namespace AllBusinesLands.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationultimoscambios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bienes", "image_path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bienes", "image_path");
        }
    }
}
