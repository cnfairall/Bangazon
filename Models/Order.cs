
namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public User Customer { get; set; }

        public bool Open { get; set; }
        public DateTime? DatePlaced { get; set; }
        public int? PaymentTypeId { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
