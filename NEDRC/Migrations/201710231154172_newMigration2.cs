namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Description", c => c.String(nullable: false));
        }
    }
}
