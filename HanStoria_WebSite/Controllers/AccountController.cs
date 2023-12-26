﻿using HanStoria_WebSite.Entity;
using HanStoria_WebSite.Identity;
using HanStoria_WebSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanStoria_WebSite.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<ApplicationRole> RoleManager;
        // GET: Account

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.TamAd == username).Select(i => new UserOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
            }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AdresBasligi = i.AdresBasligi,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                {
                    ProductId = a.ProductId,
                    Price=a.Price,
                    ProductName = a.Product.Name,
                    PhotoName = a.Product.PhotoName,
                    Quantity = a.Quantity,
                }).ToList()
            }).FirstOrDefault();

            return View(entity);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atayabiliriz.
                    if (RoleManager.RoleExists("User"))
                    {
                        UserManager.AddToRole(user.Id, "User");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Giriş işlemleri
                var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    //varolan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluştur ve sisteme bırak.
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var IdentityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = (new AuthenticationProperties());

                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, IdentityClaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı giriş hatası.");
                }
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}