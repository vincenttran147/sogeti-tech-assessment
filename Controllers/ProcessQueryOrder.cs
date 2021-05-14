using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models;
using Utils;

namespace Triggers
{
    [ApiController]
	[Route("api/[controller]")]
    public class ProcessQueryOrder: ControllerBase
    {
        [HttpGet]
        public IActionResult Get(JObject data)
        {
            Customer customer = JsonConvert.DeserializeObject<Customer>(data.ToString());
            List<Order> queryResult = OrderUtils.QueryOrder((order) => {
                return CustomerUtils.CompareCustomer(order.customer, customer);
            });
            return queryResult.Count >= 1 ?
                (ActionResult)new OkObjectResult(JsonConvert.SerializeObject(queryResult, Formatting.Indented)) :
                new BadRequestObjectResult("No result found");
        }
    }
}