namespace OnlineRezervacijaBioskopskihKarata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_image_to_projection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projections", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projections", "Image");
        }
    }
}
