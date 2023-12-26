using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HanStoriaEntity.Entity;


namespace HanStoria_WebSite.Entity
{
    public class ProductOfWeek
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public Product Product{ get; set; }

    }
}