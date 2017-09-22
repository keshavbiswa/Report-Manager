namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedSignature : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Signature", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Signature", c => c.Binary(nullable: false));
        }
    }
}
