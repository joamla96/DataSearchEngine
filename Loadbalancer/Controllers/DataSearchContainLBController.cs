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
    public class DataSearchContainLBController : ControllerBase
    {
		private ILoadBalancer loadBalancer;

		public DataSearchContainLBController(ILoadBalancer loadBalancer)
		{
			this.loadBalancer = loadBalancer;
		}

        // GET: api/Default
        [HttpGet]
        public IActionResult Get()
        {
			return Ok(loadBalancer.Next());
        }
    }
}
