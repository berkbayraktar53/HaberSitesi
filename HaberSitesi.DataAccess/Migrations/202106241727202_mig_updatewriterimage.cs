namespace HaberSitesi.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updatewriterimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterImage");
        }
    }
}
