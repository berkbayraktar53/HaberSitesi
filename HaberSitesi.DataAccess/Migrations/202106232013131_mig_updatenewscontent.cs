namespace HaberSitesi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updatenewscontent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "NewsContent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "NewsContent", c => c.String(maxLength: 1000));
        }
    }
}
