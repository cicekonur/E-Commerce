namespace ETicaret.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloIsımleriDegisti : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Kategoris", newName: "Kategoriler");
            RenameTable(name: "dbo.Uruns", newName: "Urunler");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Urunler", newName: "Uruns");
            RenameTable(name: "dbo.Kategoriler", newName: "Kategoris");
        }
    }
}
