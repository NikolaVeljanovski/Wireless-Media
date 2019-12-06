namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PromenaProizvoda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proizvods", "Naziv", c => c.String(nullable: false));
            AlterColumn("dbo.Proizvods", "Opis", c => c.String(nullable: false));
            AlterColumn("dbo.Proizvods", "Kategorija", c => c.String(nullable: false));
            AlterColumn("dbo.Proizvods", "Proizvodjac", c => c.String(nullable: false));
            AlterColumn("dbo.Proizvods", "Dobavljac", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proizvods", "Dobavljac", c => c.String());
            AlterColumn("dbo.Proizvods", "Proizvodjac", c => c.String());
            AlterColumn("dbo.Proizvods", "Kategorija", c => c.String());
            AlterColumn("dbo.Proizvods", "Opis", c => c.String());
            AlterColumn("dbo.Proizvods", "Naziv", c => c.String());
        }
    }
}
