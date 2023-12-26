using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HanStoria_WebSite.Entity
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Diğer özellikler buraya eklenebilir
        public string PhotoName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }

}