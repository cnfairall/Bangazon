namespace Bangazon.Dtos
{
    public class CloseCartDto
    {
        public int OrderId { get; set; }
        public bool Open { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime DatePlaced { get; set; }

    }
}
