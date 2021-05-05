namespace Focus5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sliki : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageId = c.Int(nullable: false),
                        ImageName = c.String(),
                        ImageByte = c.Binary(),
                        ImagePath = c.String(),
                        IsDeleted = c.Boolean(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ChangePasswordViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OldPassword = c.String(nullable: false),
                        NewPassword = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        ImageId = c.Int(),
                        ImageStore_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageStores", t => t.ImageStore_Id)
                .Index(t => t.ImageStore_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageStores", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChangePasswordViewModels", "ImageStore_Id", "dbo.ImageStores");
            DropIndex("dbo.ChangePasswordViewModels", new[] { "ImageStore_Id" });
            DropIndex("dbo.ImageStores", new[] { "User_Id" });
            DropTable("dbo.ChangePasswordViewModels");
            DropTable("dbo.ImageStores");
        }
    }
}
