namespace OnlineRezervacijaBioskopskihKarata.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_row_and_col_to_reservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Row", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "Column", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Column");
            DropColumn("dbo.Reservations", "Row");
        }
    }
}
