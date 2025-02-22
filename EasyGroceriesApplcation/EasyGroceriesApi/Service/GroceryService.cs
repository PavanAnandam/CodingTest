using EasyGroceriesApi.Models;

namespace EasyGroceriesApi.Services
{
    public class GroceryService
    {
        private readonly List<GroceryItem> _items = new()
        {
            new GroceryItem { Id = 1, Name = "Milk", Description = "The best of cows", Price = 2.50M },
            new GroceryItem { Id = 2, Name = "Bread", Description = "Easy toast", Price = 1.50M },
            new GroceryItem { Id = 3, Name = "Eggs", Description = "Wild chicken", Price = 3.00M }
        };

        public List<GroceryItem> GetAll() => _items;
    }
}
