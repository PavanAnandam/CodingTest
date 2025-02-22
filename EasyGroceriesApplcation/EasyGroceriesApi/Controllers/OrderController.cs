using EasyGroceriesApi.Models;
using EasyGroceriesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyGroceriesApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderProcessor _orderProcessor;
        public OrderController(OrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            var processedOrder = _orderProcessor.ProcessOrder(order);
            return Ok(processedOrder);
        }

        [HttpGet("latest")]
        public IActionResult GetLatestOrder()
        {
            var latestOrder = _orderProcessor.GetLatestOrder();
            if (latestOrder == null)
            {
                return NotFound("No recent order found.");
            }
            return Ok(latestOrder);
        }
    }
}
