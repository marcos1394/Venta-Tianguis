using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venta_Tianguis.BusinessSvc;
using Venta_Tianguis.Models;

namespace Venta_Tianguis.Controllers
{
    [Authorize]
    public class Seller : Controller
    {
        private IGarageSaleService svc;

        string UserEmail => User?.Identity?.Name ?? string.Empty;

        
        public Seller(IGarageSaleService svc)
        {
            this.svc = svc;
        }
        public IActionResult Index(IEnumerable<ListingSummary> listings)
        {
            var user = svc.GetUser(UserEmail);
            _ = svc.GetUserListings();
            var model = new SellerModel(user.Name, user.Email, (IEnumerable<ListingSummary>?)svc.GetUserListings());
            return View(model);
        }

        public IActionResult AddNew()
        {
            var model = new ListingDetail(-1, DateTime.Now, svc.GetUser("marcosbancaprepa@gmail.com").Name, "marcosbancaprepa@gmail.com", "", "", 0f);
            return View("Edit", model);
        }

        public IActionResult Edit(int id)
        {
            var model = svc.GetListing(id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            svc.DeleteItem(id);
            return RedirectToAction("Index");
        }

        public IActionResult SaveItem(ListingDetail item)
        {
            if (!ModelState.IsValid) return View("Edit", item);
            svc.SaveListing(item);
            return RedirectToAction("Index");
        }
    }
}
