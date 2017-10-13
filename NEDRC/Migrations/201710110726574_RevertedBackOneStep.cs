namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertedBackOneStep : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DemoModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DemoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
