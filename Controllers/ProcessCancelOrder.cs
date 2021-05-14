using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models;
using Utils;

namespace Controllers
{
    [ApiController]
	[Route("api/[controller]")]
    public class ProcessCancelOrder: ControllerBase
    {
        [HttpGet]
        public IActionResult Get(JObject data)
        {
            Order newOrder = JsonConvert.DeserializeObject<Order>(data.ToString());
            string orderId = newOrder.orderId;

            return OrderUtils.RemoveOrder((order) => order.orderId == newOrder.orderId) ?
                (ActionResult)new OkObjectResult($"Removed order with order ID: {orderId}") :
                new BadRequestObjectResult("No result found, nothing to remove");
        }
    }
}