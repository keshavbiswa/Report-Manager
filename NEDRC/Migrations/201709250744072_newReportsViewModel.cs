namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newReportsViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "DateTime", c => c.Single(nullable: false));
        }
    }
}
