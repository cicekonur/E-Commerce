namespace ETicaret.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrunVeKategoriEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        KategoriAdi = c.String(maxLength: 50, unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Aciklama = c.String(maxLength: 2000, unicode: false),
                        Money = c.Decimal(nullable: false, storeType: "money"),
                        EklemeTarihi = c.DateTime(storeType: "date"),
                        Stok = c.Int(),
                        KategoriId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategoris", t => t.KategoriId)
                .Index(t => t.KategoriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uruns", "KategoriId", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "KategoriId" });
            DropTable("dbo.Uruns");
            DropTable("dbo.Kategoris");
        }
    }
}
