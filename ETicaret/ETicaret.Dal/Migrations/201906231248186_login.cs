namespace ETicaret.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EMail = c.String(),
                        Sifre = c.String(),
                        Yetki = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginUruns",
                c => new
                    {
                        Login_Id = c.Guid(nullable: false),
                        Urun_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Login_Id, t.Urun_Id })
                .ForeignKey("dbo.Logins", t => t.Login_Id, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.Urun_Id, cascadeDelete: true)
                .Index(t => t.Login_Id)
                .Index(t => t.Urun_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginUruns", "Urun_Id", "dbo.Urunler");
            DropForeignKey("dbo.LoginUruns", "Login_Id", "dbo.Logins");
            DropIndex("dbo.LoginUruns", new[] { "Urun_Id" });
            DropIndex("dbo.LoginUruns", new[] { "Login_Id" });
            DropTable("dbo.LoginUruns");
            DropTable("dbo.Logins");
        }
    }
}
