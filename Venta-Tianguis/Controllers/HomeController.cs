using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Venta_Tianguis.Areas.Identity.Data;
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


        public IActionResult SeedDb(UserManager<Venta_TianguisUser> userManager,
            [FromServices]IPasswordHasher<Venta_TianguisUser> hasher) 
        {
            Venta_TianguisUser user = new()
            {
                FullName = "Marcos Sandoval",
                Email = "marcosbancaprepa@gmail.com",
                UserName = "marcosbancaprepa@gmail.com",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(user, "Heisenberg1394?");
            user.Items = new List<Item>()
            {
                new Item() {ListingDate = DateTime.Now, Price = 2011.90F, Title="Producto Prueba",
                Description= @"este es un producto de prueba"},
                new Item() {ListingDate = DateTime.Now, Price = 2011.90F, Title="Producto Prueba",
                Description= @"este es un producto de prueba"},
                new Item() {ListingDate = DateTime.Now, Price = 2011.90F, Title="Producto Prueba",
                Description= @"este es un producto de prueba"}
            };

            userManager.CreateAsync(user).Wait();
            user = new()
            {
                FullName = "Xanizzin Rivera",
                Email = "cotariverax@gmail.com",
                UserName = "cotariverax@gmail.com",
                EmailConfirmed = true,
            };
            user.PasswordHash = hasher.HashPassword(user, "Xanizzin123");
            user.Items = new List<Item>()
            {
                new Item() {ListingDate = DateTime.Now, Price = 2011.90F, Title="Producto Prueba",
                Description= @"este es un producto de prueba"},
                new Item() {ListingDate = DateTime.Now, Price = 2011.90F, Title="Producto Prueba",
                Description= @"este es un producto de prueba"},
                new Item() {ListingDate = DateTime.Now, Price = 2011.90F, Title="Producto Prueba",
                Description= @"este es un producto de prueba"}
            };
            userManager.CreateAsync(user).Wait();
            return RedirectToAction("Index");
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