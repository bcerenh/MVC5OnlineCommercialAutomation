namespace MvcWebTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mesajs",
                c => new
                {
                    MesajID = c.Int(nullable: false, identity: true),
                    Gonderici = c.String(maxLength: 30, unicode: false),
                    Alici = c.String(maxLength: 30, unicode: false),
                    Konu = c.String(maxLength: 30, unicode: false),
                    icerik = c.String(maxLength: 2000, unicode: false),
                    Tarih = c.DateTime(nullable: false, storeType: "smalldatetime"),
                })
                .PrimaryKey(t => t.MesajID);
        }
        
        public override void Down()
        {
        }
    }

}
//EĞER SQLDE TBLO GÜNCELLEMEK İSTERSEN AŞAĞIDAKİ ADIMLARI TAKİP ET
//ÖNCE MIGRATİON YAPTIKTAN SONRA AŞAĞIDAKİ GİBİ SİL VE UPDATE DATABASE FORCE YAP 

//You can also go to edit your last migration file("201410101740197_AutomaticMigration.cs) to empty it code inside Up(), Down() functions.

//public override void Up()
//{
//}
//public override void Down()
//{
//}