namespace NEDRC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedSignature1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Signature", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Signature", c => c.Byte(nullable: false));
        }
    }
}
