namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "UserId");
        }
    }
}
