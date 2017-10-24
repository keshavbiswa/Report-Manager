namespace NEDRC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedUsersToReports : DbMigration
    {
        
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Reports", new[] { "UserId" });
            AddColumn("dbo.Reports", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Reports", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reports", "User_Id");
            AddForeignKey("dbo.Reports", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reports", new[] { "User_Id" });
            AlterColumn("dbo.Reports", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Reports", "User_Id");
            CreateIndex("dbo.Reports", "UserId");
            AddForeignKey("dbo.Reports", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
