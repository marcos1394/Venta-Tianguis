using Venta_Tianguis.Models;

namespace Venta_Tianguis.BusinessSvc
{
    public interface IGarageSaleService
    {
        string UserEmail { get; set; }

        int GetListingCount();
        List<ListingSummary> GetListingPage(int page);
       (string Id, string Name, string Email) GetUser(string email);
        IEnumerable<ListingSummary> GetUserListings();
        ListingDetail GetListing(int id);
        void DeleteItem(int ListingId);
        void SaveListing(ListingDetail item);

    }
}
