using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ShopMVC.DataAccess
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection") { }  // Empty constructor 
        public DbSet<Models.StockItem> Items { get; set; }
    }
}