﻿using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AdventureTravels.Models;
using AdventureTravels.Contracts.Data;
using AdventureTravels.Contracts.Repositories;
using AdventureTravels.Services;

namespace AdventureTravels.WebUI.Controllers
{
    public class ProductsController : Controller
    {

        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<BasketItem> basketitems;
        BasketService basketService;

        public ProductsController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Basket> baskets, IRepositoryBase<BasketItem> basketitems, IRepositoryBase<Coupon> coupons, IRepositoryBase<CouponType> couponTypes)
        {
            this.customers = customers;
            this.products = products;
            this.baskets = baskets;
            this.basketitems = basketitems;
            basketService = new BasketService(this.baskets, this.basketitems, coupons, couponTypes);
        }

        public ActionResult QuantityInBasket()
        {
            var result = basketService.QuantityInBasket(this.HttpContext);
            return Json(result);
        }

        public ActionResult AddToBasket(int id)
        {
            basketService.AddToBasket(this.HttpContext, id, 1);//always add one to the basket
            return RedirectToAction("BasketSummary");
        }

        public ActionResult AddBasketCoupon(string couponCode)
        {
            basketService.AddCoupon(couponCode, this.HttpContext);

            return RedirectToAction("BasketSummary");
        }

        public ActionResult BasketSummary()
        {
            ViewBag.QuantityInBasket = basketService.QuantityInBasket(this.HttpContext);
            ViewBag.AmountInBasket = basketService.AmountInBasket(this.HttpContext);
            var model = basketService.GetBasket(this.HttpContext);
            return View(model);
        }

        public ActionResult BasketItemDetails(int? id)
        {
            var product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult BasketItemAdd(string searchString, string sortOrder)
        {
            var product = products.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Description.Contains(searchString));
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            switch (sortOrder)
            {
                case "name_desc":
                    product = product.OrderByDescending(s => s.Description);
                    break;
                case "Price":
                    product = product.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    product = product.OrderByDescending(s => s.Price);
                    break;
                default:
                    product = product.OrderBy(s => s.Description);
                    break;
            }

            return View(product);
        }


        public ActionResult DeleteFromBasket(int id)
        {
            BasketItem basketItem = basketService.GetBasketItemById(id);            
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            return View(basketItem);
        }

        [HttpPost, ActionName("DeleteFromBasket")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            basketService.RemoveFromBasket(id);
            return RedirectToAction("BasketSummary");
        }

        // GET: list with filter
        public ActionResult Index(string searchString, string sortOrder)
        {
            var product = products.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Description.Contains(searchString));
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            switch (sortOrder)
            {
                case "name_desc":
                    product = product.OrderByDescending(s => s.Description);
                    break;
                case "Price":
                    product = product.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    product = product.OrderByDescending(s => s.Price);
                    break;
                default:
                    product = product.OrderBy(s => s.Description);
                    break;
            }

            return View(product);
        }

        // GET: /Details/5
        public ActionResult Details(int? id)
        {
            var product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}
