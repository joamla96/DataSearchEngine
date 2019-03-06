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
        public IActionResult Post([FromBody]SearchQuerryDTO item)
        {
			if (item.Querry == null)
				return BadRequest();

			var server = this.loadBalancer.Next();
			var client = new RestClient(server.Host.ToUriComponent());
			var request = new RestRequest(server.PathBase, Method.POST);
			request.AddJsonBody(item);

			var result = client.Execute(request);
			
			if(!result.IsSuccessful) 
				return StatusCode((int)result.StatusCode, result.StatusDescription);

			return Ok(result.Content);
		}
    }
}
