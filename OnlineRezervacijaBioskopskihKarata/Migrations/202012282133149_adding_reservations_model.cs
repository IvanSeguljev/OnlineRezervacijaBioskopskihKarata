namespace OnlineRezervacijaBioskopskihKarata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_reservations_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectionId = c.Int(nullable: false),
                        OrderId = c.String(),
                        TicketGuid = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .Index(t => t.ProjectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ProjectionId", "dbo.Projections");
            DropIndex("dbo.Reservations", new[] { "ProjectionId" });
            DropTable("dbo.Reservations");
        }
    }
}
