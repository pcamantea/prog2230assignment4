using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AdventureTravels.Models;
using AdventureTravels.Models.ViewModel;
using AdventureTravels.Contracts.Data;
using AdventureTravels.Contracts.Repositories;
using System.Data.Entity;

namespace AdventureTravels.WebUI.Controllers
{
    public class AdminController : Controller
    {

        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Order> orders;
        IRepositoryBase<Coupon> coupons;
        IRepositoryBase<CouponType> couponTypes;

        public AdminController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Order> orders, IRepositoryBase<Coupon> coupons, IRepositoryBase<CouponType> couponTypes)
        {
            this.customers = customers;
            this.products = products;
            this.coupons = coupons;
            this.couponTypes = couponTypes;
            this.orders = orders;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductIndex(string searchString, string sortOrder)
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
        public ActionResult ProductDetails(int? id)
        {
            var product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Create
        public ActionResult ProductCreate()
        {
            var product = new Product();
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductCreate(Product product)
        {
            products.Insert(product);
            products.Commit();

            return RedirectToAction("ProductIndex");
        }

        // GET: /Edit/5
        public ActionResult ProductEdit(int id)
        {
            Product product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(Product product)
        {
            products.Update(product);
            products.Commit();

            return RedirectToAction("ProductIndex");
        }

        // GET: /Delete/5
        public ActionResult ProductDelete(int id)
        {
            Product product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("ProductDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ProdcutDeleteConfirm(int id)
        {
            products.Delete(products.GetById(id));
            products.Commit();
            return RedirectToAction("ProductIndex");
        }

        // GET: list with filter
        public ActionResult CustomerIndex(string searchString)
        {
            var customer = customers.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                customer = customer.Where(s => s.CustomerName.Contains(searchString));
            }

            return View(customer);
        }

        // GET: /Details/5
        public ActionResult CustomerDetails(int? id)
        {
            var customer = customers.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Create
        public ActionResult CustomerCreate()
        {
            var customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerCreate(Customer customer)
        {
            customers.Insert(customer);
            customers.Commit();

            return RedirectToAction("CustomerIndex");
        }

        // GET: /Edit/5
        public ActionResult CustomerEdit(int id)
        {
            Customer customer = customers.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerEdit(Customer customer)
        {
            customers.Update(customer);
            customers.Commit();

            return RedirectToAction("CustomerIndex");
        }

        // GET: /Delete/5
        public ActionResult CustomerDelete(int id)
        {
            Customer customer = customers.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost, ActionName("CustomerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerDeleteConfirm(int id)
        {
            customers.Delete(customers.GetById(id));
            customers.Commit();
            return RedirectToAction("CustomerIndex");
        }

        public ActionResult OrderIndex(string searchString1, string searchString2, string sortOrder)
        {
            DataContext contextForIndex = new DataContext();
            var viewModel =
                from o in contextForIndex.Orders
                join c in contextForIndex.Customers on o.CustomerId equals c.CustomerId
                select new OrderViewModel { Order = o, Customer = c };

            if (!String.IsNullOrEmpty(searchString1))
            {
                viewModel = viewModel.Where(s => s.Order.OrderId.ToString().Contains(searchString1));
            }

            if (!String.IsNullOrEmpty(searchString2))
            {
                viewModel = viewModel.Where(s => s.Customer.CustomerName.Contains(searchString2));
            }

            ViewBag.OrderIdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.OrderDateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CustomerNameSortParm = sortOrder == "Customer" ? "name_desc" : "Customer";

            switch (sortOrder)
            {
                case "id_desc":
                    viewModel = viewModel.OrderByDescending(s => s.Order.OrderId);
                    break;
                case "Date":
                    viewModel = viewModel.OrderBy(s => s.Order.OrderDate);
                    break;
                case "date_desc":
                    viewModel = viewModel.OrderByDescending(s => s.Order.OrderDate);
                    break;
                case "Customer":
                    viewModel = viewModel.OrderBy(s => s.Customer.CustomerName);
                    break;
                case "name_desc":
                    viewModel = viewModel.OrderByDescending(s => s.Customer.CustomerName);
                    break;
                default:
                    viewModel = viewModel.OrderBy(s => s.Order.OrderId);
                    break;
            }

            return View(viewModel);
        }

        // GET: /Details/5
        public ActionResult OrderDetails(int? id)
        {
            var order = orders.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            DataContext contextForIndex = new DataContext();
            var viewModel =
                from o in contextForIndex.Orders
                join c in contextForIndex.Customers on o.CustomerId equals c.CustomerId
                where o.OrderId == id
                select new OrderViewModel { Order = o, Customer = c };

            return View(viewModel);

        }
        // GET: /Create
        public ActionResult OrderCreate()
        {
            var order = new Order();

            // viewBag for DropdownList
            var customer = customers.GetAll();
            ViewBag.Customer = customer.OrderBy(s => s.CustomerName);

            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderCreate(Order order)
        {
            orders.Insert(order);
            orders.Commit();

            return RedirectToAction("OrderIndex");
        }

        // GET: /Edit/5
        public ActionResult OrderEdit(int id)
        {
            Order order = orders.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            // viewBag for DropdownList
            var customer = customers.GetAll();
            ViewBag.Customer = customer.OrderBy(s => s.CustomerName);

            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderEdit(Order order)
        {
            orders.Update(order);
            orders.Commit();

            return RedirectToAction("OrderIndex");
        }

        // GET: /Delete/5
        public ActionResult OrderDelete(int id)
        {
            Order order = orders.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            DataContext contextForIndex = new DataContext();
            var viewModel =
                from o in contextForIndex.Orders
                join c in contextForIndex.Customers on o.CustomerId equals c.CustomerId
                where o.OrderId == id
                select new OrderViewModel { Order = o, Customer = c };

            return View(viewModel);
        }
        [HttpPost, ActionName("OrderDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult OrderDeleteConfirm(int id)
        {
            orders.Delete(orders.GetById(id));
            orders.Commit();
            return RedirectToAction("OrderIndex");
        }

        #region Coupon CRUD
        public ActionResult CouponList()
        {
            var model = coupons.GetAll();

            return View(model);
        }

        public ActionResult CreateCoupon()
        {
            var model = new Coupon();
            ViewBag.couponTypes = couponTypes.GetAll();
            ViewBag.products = products.GetAll();

            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCoupon(Coupon coupon)
        {
            coupons.Insert(coupon);
            coupons.Commit();

            return RedirectToAction("CouponList");
        }

        public ActionResult EditCoupon(int id)
        {
            Coupon coupon = coupons.GetById(id);
            return View(coupon);
        }
        [HttpPost]
        public ActionResult EditCoupon(Coupon coupon)
        {
            coupons.Update(coupon);
            coupons.Commit();
            return RedirectToAction("CouponList");
        }
        [HttpDelete]
        public ActionResult DeleteCoupon(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            coupons.GetById(id);
            if (coupons == null)
            {
                return HttpNotFound();
            }
            else
            {
                coupons.Delete(id);
            }
            return View(couponTypes);
        }

        public ActionResult DeleteCoupon(int id)
        {
            coupons.Delete(id);
            coupons.Commit();

            return RedirectToAction("CouponList");
        }
        #endregion

        #region CouponType CRUD

        public ActionResult CouponTypeList()
        {
            var model = couponTypes.GetAll();
            return View(model);
        }

        public ActionResult CreateCouponType()
        {
            var model = new CouponType();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCouponType(CouponType couponType)
        {
            couponTypes.Insert(couponType);
            couponTypes.Commit();
            return RedirectToAction("CouponTypeList");
        }

        public ActionResult EditCouponType(int id)
        {
            CouponType couponType = couponTypes.GetById(id);
            return View(couponType);
        }

        [HttpPost]
        public ActionResult EditCouponType(CouponType couponType)
        {
            couponTypes.Update(couponType);
            couponTypes.Commit();

            return RedirectToAction("CouponTypeList");
        }
        //Try 1 - No go
        //public ActionResult DeleteCouponType(int id)
        //{
        //    couponTypes.GetById(id);
        //    if (couponTypes == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(couponTypes);
        //}

        //Original method
        //[HttpDelete]
        public ActionResult DeleteCouponType(int id)
        {
            couponTypes.Delete(id);
            couponTypes.Commit();

            return RedirectToAction("CouponTypeList");
        }
        //Try 2 - No go
        //[HttpPost, ActionName("DeleteCouponType")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteCouponType(int? id, bool? saveChangesError = false)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    if (saveChangesError.GetValueOrDefault())
        //    {
        //        ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
        //    }
        //    couponTypes.GetById(id);
        //    if (couponTypes == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        couponTypes.Delete(id);
        //    }
        //    return View(couponTypes);
        //}
        #endregion
    }

}