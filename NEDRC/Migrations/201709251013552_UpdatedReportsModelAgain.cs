namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedReportsModelAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reports", "Description");
            DropColumn("dbo.Reports", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "Category", c => c.String(nullable: false));
            AddColumn("dbo.Reports", "Description", c => c.String());
        }
    }
}
