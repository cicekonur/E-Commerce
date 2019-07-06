namespace ETicaret.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabloDoldur : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO kategoriler values('fc6d4fe1-ad83-42a6-a53b-c639f90c124a','Elektronik',0)");
            Sql("INSERT INTO kategoriler values('b3042345-036c-4884-918c-12eee2a640b8','Moda',0)");
            Sql("INSERT INTO kategoriler values('f29c89a9-b364-4ad7-8069-4a84891932c8','Ofis',0)");
            Sql("INSERT INTO kategoriler values('6256a023-8ec0-4248-842f-351603e2bf2f','Spor',0)");


          //  Sql("INSERT INTO Urunler values('ecdda3e5-0fd0-490c-ad3a-6fa0de9f0fc3','9 kilogramlýk yýkama kapasitesine sahip olan ve A+++ enerji verimliði sýnýfýnda yer alan Samsung WW90J5475FW/AH A+++ 1400 Devir 9 kg Çamaþýr Makinesi, kullanýcýlarýn tüm beklentilerini eksiksiz olarak karþýlamayý baþarýyor. Hem güçlü ve sessiz çalýþma performansý sunan hem de enerjiyi son derece tasarruflu bir þekilde tüketen bu geliþmiþ çamaþýr makinesi modeli ile siz de geleneksel bir beyaz eþyadan çok daha fazlasýna sahip olabilirsiniz.',2500,'2017/08/25',25,'fc6d4fe1-ad83-42a6-a53b-c639f90c124a',0)");
           // ileriki migrationlardan ürünleri buradan eklersin.
           
        }
        
        public override void Down()
        {
        }
    }
}
