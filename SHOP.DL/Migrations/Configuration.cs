﻿namespace SHOP.DL.Migrations
{
    using System;
    
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<SHOP.DL.ShopEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SHOP.DL.ShopEntity";
        }


       
        protected override void Seed(SHOP.DL.ShopEntity context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
