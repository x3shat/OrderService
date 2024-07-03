using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OrderService.Models;
using OrderService.Services;
using OrderService.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService.Services.OrderService _orderService;

        public OrdersController(OrderService.Services.OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<Order>> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        [Authorize(Roles = "InventoryWorker")]
        public async Task<ActionResult> AddOrder([FromBody] OrderRequest orderRequest)
        {
            var createdBy = User.FindFirst("Username")?.Value;
            await _orderService.AddOrder(orderRequest, createdBy);
            return Ok();
        }

        [HttpPut("{orderId}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> UpdateOrder(int orderId, [FromBody] OrderRequest orderRequest)
        {
            var updatedBy = User.FindFirst("Username")?.Value;
            var result = await _orderService.UpdateOrder(orderId, orderRequest, updatedBy);
            if (!result) return NotFound();
            return Ok();
        }

        [HttpDelete("{orderId}")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> DeleteOrder(int orderId)
        {
            var deletedBy = User.FindFirst("Username")?.Value;
            var result = await _orderService.DeleteOrder(orderId, deletedBy);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
