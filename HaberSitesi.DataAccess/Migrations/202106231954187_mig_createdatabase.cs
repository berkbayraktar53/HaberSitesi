namespace HaberSitesi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(maxLength: 100),
                        NewsContent = c.String(maxLength: 1000),
                        NewsImage = c.String(maxLength: 100),
                        NewsDate = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.WriterID);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterID = c.Int(nullable: false, identity: true),
                        WriterName = c.String(maxLength: 50),
                        WriterSurname = c.String(maxLength: 50),
                        WriterEmail = c.String(maxLength: 50),
                        WriterPassword = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.WriterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.News", "CategoryID", "dbo.Categories");
            DropIndex("dbo.News", new[] { "WriterID" });
            DropIndex("dbo.News", new[] { "CategoryID" });
            DropTable("dbo.Writers");
            DropTable("dbo.News");
            DropTable("dbo.Categories");
        }
    }
}
