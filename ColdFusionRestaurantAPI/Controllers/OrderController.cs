using Abstract;
using Business.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace ColdFusionRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("Create")]
        public IActionResult Create(CreateOrderRequest orderRequests)
        {
            if (orderRequests == null)
            {
                return BadRequest("Sipariş listesi boş olamaz.");
            }

            try
            {
                _orderService.CreateOrder(orderRequests);
                return Ok("Siparişler başarıyla oluşturuldu!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Siparişler oluşturulurken bir hata oluştu: " + ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<GetOrderResponse>> GetCustomerOrder([FromQuery] GetOrderRequest getOrderRequest)
        {
            return Ok(_orderService.GetOrder(getOrderRequest));
        }
    }
}
