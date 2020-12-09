namespace SHOP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SellerRegistrations",
                c => new
                    {
                        seller_id = c.Int(nullable: false, identity: true),
                        seller_name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        seller_email_id = c.String(nullable: false, maxLength: 8000, unicode: false),
                        seller_Mobile_no = c.String(nullable: false, maxLength: 8000, unicode: false),
                        seller_password = c.String(nullable: false, maxLength: 8000, unicode: false),
                        seller_address = c.String(nullable: false, maxLength: 8000, unicode: false),
                        seller_status = c.String(nullable: false, maxLength: 8000, unicode: false),
                      seller_reg_date = DateTime.Now,
                    seller_update_date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.seller_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SellerRegistrations");
        }
    }
}
