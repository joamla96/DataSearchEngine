using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loadbalancer.Balancer;
using Loadbalancer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

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
		
		[HttpGet]
		public IActionResult Get() {
			return Ok(loadBalancer.Next());
		}

        [HttpPost]
        public IRestResponse Post([FromBody]SearchQuerryDTO item)
        {
			var server = this.loadBalancer.Next();
			var client = new RestClient(server.Host.ToUriComponent());
			var request = new RestRequest(server.PathBase, Method.POST);
			request.AddJsonBody(item);

			return client.Execute(request);
		}
    }
}
