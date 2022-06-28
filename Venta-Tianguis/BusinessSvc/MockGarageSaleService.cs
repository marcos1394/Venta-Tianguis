using Venta_Tianguis.Models;

namespace Venta_Tianguis.BusinessSvc
{
    public class MockGarageSaleService : IGarageSaleService
    {

        public string UserEmail { get; set; }
        public void DeleteItem(int ListingId)
        {
            throw new NotImplementedException();
        }

        public ListingDetail GetListing(int id)
        {
            return new ListingDetail(id, DateTime.Today, "Marcos Sandoval", "marcosbancaprepa@gmail.com", "Camisa Cuadros", @"Camisa Cuadros color azul con negro", 2124);
        }

        public int GetListingCount()
        {
            return 5;
        }

        public List<ListingSummary> GetListingPage(int page)
        {
            return new List<ListingSummary>()
            { new ListingSummary(1, "Camisa Caudros", 1899),
                new ListingSummary(2, "Pantalon de Mezclilla", 2402),
                new ListingSummary(3, "Playera cuello redondo", 100)
            };
        }
        public (string Id, string Name, string Email) GetUser(string email)
        {
            return ("2", "Marcos Sandoval", "marcosbancaprepa@gmail.com");
        }

        public IEnumerable<ListingSummary> GetUserListings()
        {
            return new List<ListingSummary>()
            {
                new ListingSummary(1,"Camisa Cuadros", 1899),
                new ListingSummary(2,"Pantalon Mezclilla", 2402),
                new ListingSummary(3, "Playera Cuello Redondo", 100)
            };
        }

        public void SaveListing(ListingDetail item)
        {
            throw new NotImplementedException();
        }
    }
}
