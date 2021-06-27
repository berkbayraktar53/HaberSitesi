﻿namespace HaberSitesi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updatenewsimage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "NewsImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "NewsImage", c => c.String(maxLength: 100));
        }
    }
}
