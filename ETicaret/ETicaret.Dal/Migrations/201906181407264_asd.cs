namespace ETicaret.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Urunler", "Fiyat", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.Urunler", "ResimYolu", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Urunler", "UrunAdi", c => c.String(nullable: false, maxLength: 500, unicode: false));
            DropColumn("dbo.Urunler", "Money");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Urunler", "Money", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Urunler", "UrunAdi", c => c.String(maxLength: 500, unicode: false));
            DropColumn("dbo.Urunler", "ResimYolu");
            DropColumn("dbo.Urunler", "Fiyat");
        }
    }
}
