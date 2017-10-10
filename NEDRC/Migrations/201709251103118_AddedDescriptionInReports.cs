namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionInReports : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Description");
        }
    }
}
