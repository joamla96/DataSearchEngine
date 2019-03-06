using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loadbalancer.Balancer;
using Loadbalancer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Common.Logger;
using System.Diagnostics;

namespace Loadbalancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSearchContainLBController : ControllerBase
    {
		private ILoadBalancer loadBalancer;
		private Log Log;

		public DataSearchContainLBController(ILoadBalancer loadBalancer, Log log)
		{
			this.loadBalancer = loadBalancer;
			this.Log = log;
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

			var timera = Stopwatch.StartNew();
			var result = client.Execute(request); // IDEA: In case of exception or other, repeat request to another service?
			timera.Stop();

			Log.Write("loadbalancer", String.Format("Request to service {0} took {1} ms", server.ServiceId, timera.ElapsedMilliseconds));

			if(!result.IsSuccessful) 
				return StatusCode((int)result.StatusCode, result.StatusDescription);

			return Ok(result.Content);
		}
    }
}
