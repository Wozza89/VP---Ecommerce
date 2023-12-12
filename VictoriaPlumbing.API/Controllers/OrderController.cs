using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Victoria.Plumbing.Domain.Models.Dto;
using Victoria.Plumbing.Models.Dto;

namespace API.Controllers
{
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("api/orders")]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            // validate the orderDto
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            _orderService.CreateOrder(orderDto);

            return Ok("Order created successfully");
        }
    }

}