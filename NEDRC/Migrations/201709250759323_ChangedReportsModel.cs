namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedReportsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Date", c => c.String(nullable: false));
            DropColumn("dbo.Reports", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reports", "Date");
        }
    }
}
