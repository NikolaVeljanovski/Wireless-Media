namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodatiProizvodi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proizvods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                        Kategorija = c.String(),
                        Proizvodjac = c.String(),
                        Dobavljac = c.String(),
                        Cena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proizvods");
        }
    }
}
