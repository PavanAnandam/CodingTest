namespace EasyGroceriesApi.Models
{
    public class OrderLine
    {
        public GroceryItem? Item { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
    }

}
