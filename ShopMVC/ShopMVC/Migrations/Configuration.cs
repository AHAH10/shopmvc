namespace ShopMVC.Migrations
{
    using ShopMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopMVC.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(ShopMVC.DataAccess.StoreContext context)
        {
            context.Items.AddOrUpdate(
                i => i.ArticleNumber,

                  new StockItem { Name = "HDD",  Price = 500, Description = "HW", Quantity = 1000, ShelfPosition = "A" },
                  new StockItem { Name = "NIC",  Price = 100, Description = "HW", Quantity = 1000, ShelfPosition = "B" },
                  new StockItem { Name = "MONITOR",  Price = 100, Description = "HW", Quantity = 1000, ShelfPosition = "C" }

                );
           
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
