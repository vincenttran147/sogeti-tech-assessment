using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models;
using Utils;

namespace Triggers
{
    [ApiController]
	[Route("api/[controller]")]
    public class ProcessUpdateOrder: ControllerBase
    {
        [HttpGet]
        public IActionResult Get(JObject data)
        {
            Order newOrder = JsonConvert.DeserializeObject<Order>(data.ToString());
            string orderId = newOrder.orderId;

            return OrderUtils.UpdateOrder(newOrder, (order) => order.orderId == newOrder.orderId) ?
                (ActionResult)new OkObjectResult($"Updated order with order ID: {orderId}") :
                new BadRequestObjectResult("No result found, nothing to update");
        }
    }
}