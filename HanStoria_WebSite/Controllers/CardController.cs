using HanStoria_WebSite.Entity;
using HanStoria_WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanStoria_WebSite.Controllers
{
    public class CardController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Card
        public ActionResult Index()
        {
            return View(GetCard());
        }
        public ActionResult AddToCard(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCard().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCard(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCard().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public Card GetCard()
        {
            var card = (Card)Session["Card"];

            if (card == null)
            {
                card = new Card();
                Session["Card"] = card;
            }
            return card;
        }
        public PartialViewResult Summary()
        {

            return PartialView(GetCard());

        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var card = GetCard();

            if (card.CardLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokHatasi", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                //Siparişi veri tabanına kaydet
                //card sıfırla
                SaveOrder(card, entity);
                card.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
        }


        private void SaveOrder(Card card, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(11111, 99999).ToString();
            order.OrderState = EnumOrderState.Waiting;
            order.Total = card.Total();
            order.OrderDate = DateTime.Now;
            order.TamAd = User.Identity.Name;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;
            order.OrderLines = new List<OrderLine>();

            foreach (var pr in card.CardLines)
            {
                var orderLine = new OrderLine();
                orderLine.Quantity = pr.Quantity;
                orderLine.Price = pr.Quantity * pr.Product.Price;
                orderLine.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderLine);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }

    }

}