using EasyGroceriesApi.Models;

namespace EasyGroceriesApi.Services
{
    public class OrderProcessor
    {
        private Order? _latestOrder;
        public Order ProcessOrder(Order order)
        {
            decimal discount = order.HasLoyaltyMembership ? 0.20M : 0;
            decimal total = 0;
            order.OrderNumber = new Random().Next(100000, 999999);

            foreach (var line in order.OrderLines)
            {
                var discountedPrice = line.Item.Price * (1 - discount);
                line.LineTotal = discountedPrice * line.Quantity;
                total += line.LineTotal;
            }

            if (order.HasLoyaltyMembership)
            {
                total += 5; // Cost for loyalty membership
            }

            order.Total = total;
            _latestOrder = order;
            return order;
        }

        public Order? GetLatestOrder()
        {
            return _latestOrder;
        }
    }
}
