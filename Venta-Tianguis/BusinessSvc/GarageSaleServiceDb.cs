using Venta_Tianguis.Areas.Identity.Data;
using Venta_Tianguis.Data;
using Venta_Tianguis.Models;

namespace Venta_Tianguis.BusinessSvc
{
    public class GarageSaleServiceDb : IGarageSaleService
    {
        private Venta_TianguisContext ctx;

        public GarageSaleServiceDb(Venta_TianguisContext ctx)
        {
            this.ctx = ctx;
        }

        public string UserEmail { get; set; }
        public Venta_TianguisUser UsuarioActual
        {
            get
            {
                return ctx.Users.Single(u => u.Email == UserEmail);
            }
        }


        public void DeleteItem(int ListingId)
        {
            var item = UsuarioActual.Items.Single(i => i.Id == ListingId);
            UsuarioActual.Items.Remove(item);
            ctx.SaveChanges();
        }

        public ListingDetail GetListing(int ListingId)
        {
            var listing = ctx.Items.Single(i => i.Id == ListingId);
            return new ListingDetail(listing.Id, listing.ListingDate, listing.User.FullName,
                listing.User.Email, listing.Title, listing.Description, listing.Price);
        }

        public int GetListingCount()
        {
            return ctx.Items.Count();
        }

        public List<ListingSummary> GetListingPage(int page)
        {
            var q = from item in ctx.Items
                    orderby item.ListingDate descending
                    select new ListingSummary(item.Id, item.Title, item.Price);
            return q.Skip(page - 1 * 20).Take(20).ToList();
        }

        public (string Id, string Name, string Email) GetUser(string email)
        {
            var user = ctx.Users.Single(u => u.Email == email);
            return (user.Id, user.FullName, user.Email);
        }

        public IEnumerable<ListingSummary> GetUserListings(int ListingId)
        {
            return UsuarioActual.Items.Select(i => new ListingSummary(i.Id, i.Title, i.Price)).ToList();
        }

        public IEnumerable<ListingSummary> GetUserListings()
        {
            throw new NotImplementedException();
        }

        public void SaveListing(ListingDetail model)
        {
            Item item;
            if (model.Id < 1)
            {
                item = new Item();
                UsuarioActual.Items.Add(item);
            }
            else

                item = ctx.Items.Single(u => u.Id == model.Id);
            item.Title = model.Title;
            item.Price = model.Price;
            item.Description = model.Description;
            item.ListingDate = DateTime.Now;
            ctx.SaveChanges();

        }
    }
}