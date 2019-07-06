namespace ETicaret.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kullanicikayittarihieklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "KayitTarihi", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "KayitTarihi");
        }
    }
}
