namespace SHOP.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertdatetimetodate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SellerRegistrations", "seller_reg_date", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SellerRegistrations", "seller_reg_date", c => c.DateTime(nullable: false));
        }
    }
}
