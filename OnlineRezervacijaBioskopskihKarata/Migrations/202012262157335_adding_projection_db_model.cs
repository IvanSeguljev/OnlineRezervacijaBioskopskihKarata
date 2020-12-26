namespace OnlineRezervacijaBioskopskihKarata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_projection_db_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projections");
        }
    }
}
