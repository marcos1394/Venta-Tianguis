using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Venta_Tianguis.BusinessSvc;
using Venta_Tianguis.Models;

namespace Venta_Tianguis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGarageSaleService svc;
        
        public HomeController(ILogger<HomeController> logger, IGarageSaleService svc)
        {
            this.svc = svc;
            _logger = logger;
        }

        public IActionResult Index()

        {
           int pages = svc.GetListingCount() / 20;
            List<ListingSummary> items = svc.GetListingPage(1);
            var model = new ListingsModel(1, pages, items);
       
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var model = svc.GetListing(id);
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}