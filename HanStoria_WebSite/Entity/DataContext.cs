using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HanStoriaEntity.Entity;

namespace HanStoria_WebSite.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
         
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductOfWeek> ProductsOfWeek { get; set; }

        public DbSet<MainSlider> MainSliders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set;}
    }
}