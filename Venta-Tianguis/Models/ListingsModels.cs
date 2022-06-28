namespace Venta_Tianguis.Models
{

    public record ListingSummary(int id, string title, float price);

    public record ListingsModel(int page, int TotalPages, IEnumerable<ListingSummary> Listings);

    public record ListingDetail (
        int Id, DateTime ListingDate, string Seller, string SellerEmail,
        string Title,
        string Description,
        float Price);

    public record SellerModel (string SellerName, string SellerEmail, IEnumerable<ListingSummary> listings);
}

