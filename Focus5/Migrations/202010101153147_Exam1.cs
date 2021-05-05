namespace Focus5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exam1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Type = c.String(),
                        Level = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        School = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Exams", new[] { "User_Id" });
            DropTable("dbo.Exams");
        }
    }
}
