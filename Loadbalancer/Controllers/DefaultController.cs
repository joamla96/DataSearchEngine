using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loadbalancer.Balancer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loadbalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
		private ILoadBalancer loadBalancer = new RoundRobinLoadBalancer();

        // GET: api/Default
        [HttpGet]
        public IActionResult Get()
        {
			return Ok(loadBalancer.Next());
        }


        // POST: api/Default
        [HttpPost]
        public IActionResult Post([FromBody] IServiceOptions value)
        {
			loadBalancer.AddItem(value);
			return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(IServiceOptions value)
        {
			loadBalancer.RemoveItem(value);
			return Ok();
        }
    }
}
