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
		private MessageHandler msgHandler;

		public DataSearchContainLBController(ILoadBalancer loadBalancer, Log log, MessageHandler messageHandler)
		{
			this.loadBalancer = loadBalancer;
			this.Log = log;
			this.msgHandler = messageHandler;
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
			var client = new RestClient(server);
			var request = new RestRequest(server.PathAndQuery, Method.POST);
			request.AddJsonBody(item);

			var timera = Stopwatch.StartNew();
			var result = client.Execute(request); // IDEA: In case of exception or other, repeat request to another service?
			timera.Stop();

			Log.Write("loadbalancer", String.Format("Request to service {0} took {1} ms", server.Host, timera.ElapsedMilliseconds));

			if(!result.IsSuccessful) 
				return StatusCode((int)result.StatusCode, result.StatusDescription);

			return Ok(result.Content);
		}
    }
}
