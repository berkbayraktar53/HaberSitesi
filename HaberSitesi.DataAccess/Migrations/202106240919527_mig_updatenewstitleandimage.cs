﻿namespace HaberSitesi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updatenewstitleandimage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "NewsTitle", c => c.String(maxLength: 500));
            AlterColumn("dbo.News", "NewsImage", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "NewsImage", c => c.String(maxLength: 250));
            AlterColumn("dbo.News", "NewsTitle", c => c.String(maxLength: 100));
        }
    }
}
