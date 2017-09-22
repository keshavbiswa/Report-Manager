namespace NEDRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
           Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Signature]) VALUES (N'6fbe5361-9141-440c-a136-95e948170a8a', N'Guest@gmail.com', 0, N'AOmRxo7dQuck6Lx/Rc21Qj0+B/BbBq7i5y5JgnadCcDU1jN5AujbXS+lAmkeu+Bpew==', N'a34d9962-c0db-4589-bb39-22c33343fae5', NULL, 0, 0, NULL, 1, 0, N'Guest@gmail.com', N'Guest', <Binary Data>)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [Signature]) VALUES (N'b63d39a6-1165-41cd-b31f-e34a124007f4', N'admin@gmail.com', 0, N'AATG+27AWUDPvUIEZ9mKd4ACxo1snNfUrtaYGkAVAj4DVLoGtGckyfUVV8Hx+VG6gg==', N'a8337371-911b-4f3e-afce-27fbe3f56405', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com', N'Admin', <Binary Data>)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3d2df6ca-e8c2-4d23-a9e6-fa40d86eaf62', N'CanManageUsers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b63d39a6-1165-41cd-b31f-e34a124007f4', N'3d2df6ca-e8c2-4d23-a9e6-fa40d86eaf62')


");
        }
        
        public override void Down()
        {
        }
    }
}
