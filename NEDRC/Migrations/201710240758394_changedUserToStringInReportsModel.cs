namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserToStringInReportsModel : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_dbo.Reports_dbo.AspNetUsers_UserId]");
            DropForeignKey("dbo.Reports", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reports", new[] { "User_Id" });
            AddColumn("dbo.Reports", "User", c => c.String());
            DropColumn("dbo.Reports", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Reports", "User");
            CreateIndex("dbo.Reports", "User_Id");
            AddForeignKey("dbo.Reports", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
