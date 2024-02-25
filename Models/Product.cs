
namespace Bangazon.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; }
        public int CategoryId { get; set; }
        public int QuantityAvail { get; set; }
        public decimal PricePer { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
