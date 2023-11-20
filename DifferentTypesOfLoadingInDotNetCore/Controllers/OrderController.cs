using LogicLayer.ModelsDTO;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfLoadingInDotNetCore.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;
        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderDTO orderDTO)
        {
            var data = await orderService.CreateOrder(orderDTO);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
