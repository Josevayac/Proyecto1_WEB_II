namespace AllBusinesLands.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRequieredId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comentarios", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comentarios", "UserId", c => c.String(nullable: false));
        }
    }
}
