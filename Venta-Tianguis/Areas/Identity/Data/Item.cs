using System.ComponentModel.DataAnnotations;

namespace Venta_Tianguis.Areas.Identity.Data
{
    public class Item
    {
        public Item()
        {
        }

        public Item(string title, string description, float price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        public int Id { get; set; }
        public Venta_TianguisUser User { get; set; }

        public DateTime ListingDate { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }
        [Range(1, 10_1000)]
        public float Price { get; set; }


    }
}
