namespace ETicaret.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrunAdiVeUstKategoriEklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoriler", "UstKategori", c => c.Guid());
            AddColumn("dbo.Urunler", "UrunAdi", c => c.String(maxLength: 500, unicode: false));
            CreateIndex("dbo.Kategoriler", "UstKategori");
            AddForeignKey("dbo.Kategoriler", "UstKategori", "dbo.Kategoriler", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kategoriler", "UstKategori", "dbo.Kategoriler");
            DropIndex("dbo.Kategoriler", new[] { "UstKategori" });
            DropColumn("dbo.Urunler", "UrunAdi");
            DropColumn("dbo.Kategoriler", "UstKategori");
        }
    }
}
