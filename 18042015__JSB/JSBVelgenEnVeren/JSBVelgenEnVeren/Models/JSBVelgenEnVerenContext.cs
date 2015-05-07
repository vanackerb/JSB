using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JSBVelgenEnVeren.Models
{
    public class JSBVelgenEnVerenContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Velgen> Velgens { get; set; }
        public DbSet<Veren> Verens { get; set; }
        public DbSet<Banden> Bandens { get; set; }
        public DbSet<Facturatie> Facturaties { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Rapport> Rapports { get; set; }
        public DbSet<SiteBeheer> SiteBeheers { get; set; }
    }
}