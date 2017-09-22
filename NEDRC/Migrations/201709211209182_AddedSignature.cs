namespace NEDRC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedSignature : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.AspNetUsers", "Signature", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Signature");
        }
    }
}
