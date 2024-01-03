using HanStoria_WebSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanStoria_WebSite.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context=new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var productsOfWeek = _context.ProductsOfWeek.Select(p => p.ProductId).ToList();
            var weekProducts = _context.Products
                                    .Where(p => productsOfWeek.Contains(p.Id))
                                    .ToList() // Veritabanından verileri çek
                                    .Select(p => new ProductViewModel
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Description = TruncateDescription(p.Description, 70), // Bellekte kısalt
                                        PhotoName = p.PhotoName == null ? "~/img/product/ErrorPhoto.png" : p.PhotoName,
                                        Price =p.Price,
                                        CategoryId = p.CategoryId
                                        // Diğer özellikler
                                    })
                                    .ToList();

            var mainSlides = _context.MainSliders.ToList();

            ViewBag.MainSlides = mainSlides;
            return View(weekProducts);
        }

        private string TruncateDescription(string description, int maxLength)
        {
            if (string.IsNullOrEmpty(description))
                return string.Empty;

            return description.Length <= maxLength ? description : description.Substring(0, maxLength) + "...";
        }



        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var productList = _context.Products.Where(i => i.IsApproved).ToList();
     
            // Şimdi C# tarafında kısaltma işlemini gerçekleştirelim
            var truncatedProducts = productList.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = TruncateDescription(p.Description, 70), // Bellekte kısalt
                Stock = p.Stock,
                PhotoName = p.PhotoName==null? "../img/product/ErrorPhoto.png": p.PhotoName,
                Price = p.Price,
                CategoryId = p.CategoryId
                // Diğer özellikler                              
            }).AsQueryable();

            if (id!=null)
            {
                truncatedProducts = truncatedProducts.Where(i=>i.CategoryId==id);
            }
            return View(truncatedProducts.ToList());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }

        public ActionResult Search(string q)
        {
            var products = _context.Products.Where(p => p.Name.Contains(q)).ToList();
            return View(products);
        }
    }
}