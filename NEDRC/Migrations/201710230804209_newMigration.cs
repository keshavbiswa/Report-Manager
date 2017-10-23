namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reports", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.Reports", name: "IX_UserId", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reports", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Reports", name: "User_Id", newName: "UserId");
        }
    }
}
