using System.Web.Mvc;
using AdventureTravels.Contracts.Repositories;
using AdventureTravels.Contracts.Data;
using AdventureTravels.Models;

namespace AdventureTravels.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        public HomeController(IRepositoryBase<Customer> customers)
        { this.customers = customers; }

        public ActionResult Index()
        {
            //CustomerRepository customers = new CustomerRepository(new DataContext());
            ProductRepository products = new ProductRepository(new DataContext());
            OrderRepository orders = new OrderRepository(new DataContext());

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}