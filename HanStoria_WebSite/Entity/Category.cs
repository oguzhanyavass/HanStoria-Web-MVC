﻿using HanStoria_WebSite.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanStoriaEntity.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:25,ErrorMessage="En fazla 25 karakter girebilirsin.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public List <Product>Products { get; set; }

    }
}