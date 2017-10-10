namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReports : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DateTime = c.Single(nullable: false),
                        Category = c.String(nullable: false),
                        isApproved = c.Boolean(nullable: false),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}
