using System.Data.Entity;
namespace SHOP.DL
{
  public  class ShopEntity :DbContext
    {
        /// <summary>
        /// set  constructor 
        /// </summary>
        public ShopEntity():base("dbconnect")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopEntity, SHOP.DL.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<SellerRegistration>().Property(b=>b.seller_reg_date)
        }


        /// <summary>
        /// add new seller registraton table
        /// </summary>
        public DbSet<SellerRegistration> sellerRegistrations { get; set; }

    }
}
