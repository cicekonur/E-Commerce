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


          //  Sql("INSERT INTO Urunler values('ecdda3e5-0fd0-490c-ad3a-6fa0de9f0fc3','9 kilograml�k y�kama kapasitesine sahip olan ve A+++ enerji verimli�i s�n�f�nda yer alan Samsung WW90J5475FW/AH A+++ 1400 Devir 9 kg �ama��r Makinesi, kullan�c�lar�n t�m beklentilerini eksiksiz olarak kar��lamay� ba�ar�yor. Hem g��l� ve sessiz �al��ma performans� sunan hem de enerjiyi son derece tasarruflu bir �ekilde t�keten bu geli�mi� �ama��r makinesi modeli ile siz de geleneksel bir beyaz e�yadan �ok daha fazlas�na sahip olabilirsiniz.',2500,'2017/08/25',25,'fc6d4fe1-ad83-42a6-a53b-c639f90c124a',0)");
           // ileriki migrationlardan �r�nleri buradan eklersin.
           
        }
        
        public override void Down()
        {
        }
    }
}
