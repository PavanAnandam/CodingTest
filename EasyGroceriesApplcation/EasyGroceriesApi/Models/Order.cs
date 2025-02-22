namespace EasyGroceriesApi.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new();
        public bool HasLoyaltyMembership { get; set; }
        public decimal Total { get; set; }
    }

}
