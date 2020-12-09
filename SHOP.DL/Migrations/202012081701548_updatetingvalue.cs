namespace SHOP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetingvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SellerRegistrations", "seller_reg_date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
           // AlterColumn("dbo.SellerRegistrations", "seller_reg_date", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
