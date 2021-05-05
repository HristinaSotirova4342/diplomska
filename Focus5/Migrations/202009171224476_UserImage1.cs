namespace Focus5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserImage1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImage1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImage1", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserImage1", new[] { "User_Id" });
            DropTable("dbo.UserImage1");
        }
    }
}
