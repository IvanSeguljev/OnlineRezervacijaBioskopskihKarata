namespace OnlineRezervacijaBioskopskihKarata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_ticket_cost_to_projection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projections", "TicketCost", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projections", "TicketCost");
        }
    }
}
