using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HanStoriaEntity.Entity;

namespace HanStoria_WebSite.Entity
{
    public class MainSlider
    {
        public int Id { get; set; }
        public string PhotoName { get; set; }
        public string Title { get; set; }
        public string Slogan { get; set; }
        public string ButtonContent1 { get; set; }

        public string ButtonContent2 { get; set; }
    }
}