using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models;
using Utils;

namespace Triggers
{
    [ApiController]
	[Route("api/[controller]")]
    public class ProcessNewOrder: ControllerBase
    {
        [HttpGet]
        public IActionResult Get(JObject data)
        {
            Order order = JsonConvert.DeserializeObject<Order>(data.ToString());
            order.orderId = Guid.NewGuid().ToString();

            return OrderUtils.WriteOrder(order) ? (ActionResult)new OkObjectResult("Order Added") :
                new BadRequestObjectResult("Error when adding new order");
        }
    }
}