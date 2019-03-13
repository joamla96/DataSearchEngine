using EasyNetQ;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Loadbalancer.Balancer
{
	public class RoundRobinLoadBalancer
		: ILoadBalancer
	{
		public RoundRobinLoadBalancer(IConfiguration configuration) {
			List<string> apis = configuration.GetSection("API").Get<List<string>>();

			foreach(var api in apis) {
				var uri = new Uri(api);
				serviceOptions.Add(uri);
			}
		}

		/// <summary>
		/// List of services in the loadbalancer
		/// </summary>
		private List<Uri> serviceOptions = new List<Uri>();

		/// <summary>
		/// Counter for which item in the load balancer to access
		/// </summary>
		private int lastRequest = 0;
		public Uri Next()
		{
			if (serviceOptions.Count == 0)
				throw new Exception("No Service Options Defined"); // TODO Custom Exception

			if (lastRequest >= serviceOptions.Count)
				lastRequest = 0;

			return serviceOptions[lastRequest++];

		}

		/// <summary>
		/// Add an item to the list of possible services
		/// </summary>
		/// <param name="item">itme to add</param>
		public void AddInstance(Uri item)
		{
			serviceOptions.Add(item);
		}

		/// <summary>
		/// Remove item from the list of possible services
		/// </summary>
		/// <param name="item">item to remove</param>
		public void RemoveInstance(Uri item)
		{
			serviceOptions.Remove(item);
		}

		public IEnumerable<Uri> GetInstances() {
			return serviceOptions.ToList();
		}
	}
}
