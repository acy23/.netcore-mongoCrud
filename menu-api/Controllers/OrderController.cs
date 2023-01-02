using menu_api.Models;
using menu_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace menu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<Order> _logger;

        public OrderController(OrderService orderService, ILogger<Order> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            var items = await _orderService.GetAsync();
            return Ok(items);
        }
        
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            var item = await _orderService.GetAsync(id);
            if (item == null)
            {
                _logger.Log(LogLevel.Information, "Order with {id} could not found...", id);   
                return NotFound("Order not found...");
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order item)
        {
            try
            {
                await _orderService.CreateAsync(item);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, "Post method failed : {ex}", ex);
                return Forbid("Forbidden...");
            }
            return NoContent();
        }

    }
}
