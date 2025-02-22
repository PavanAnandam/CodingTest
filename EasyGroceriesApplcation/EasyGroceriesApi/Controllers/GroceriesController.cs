using EasyGroceriesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyGroceriesApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceriesController : ControllerBase
    {
        private readonly GroceryService _service;
        public GroceriesController(GroceryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetGroceries()
        {
            var items = _service.GetAll();
            return Ok(items);
        }
    }
}
