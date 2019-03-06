using EasyNetQ;
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
		/// <summary>
		/// List of services in the loadbalancer
		/// </summary>
		private List<IServiceOptions> serviceOptions = new List<IServiceOptions>();

		/// <summary>
		/// Counter for which item in the load balancer to access
		/// </summary>
		private int lastRequest = 0;
		public IServiceOptions Next()
		{
			if (serviceOptions.Count == 0)
				throw new Exception("No Service Options Defined"); // TODO Custom Exception

			++lastRequest;
			if (lastRequest > serviceOptions.Count)
				lastRequest = 0;

			return serviceOptions[lastRequest];

		}

		/// <summary>
		/// Add an item to the list of possible services
		/// </summary>
		/// <param name="item">itme to add</param>
		public void AddInstance(IServiceOptions item)
		{
			serviceOptions.Add(item);
		}

		/// <summary>
		/// Remove item from the list of possible services
		/// </summary>
		/// <param name="item">item to remove</param>
		public void RemoveInstance(IServiceOptions item)
		{
			serviceOptions.Remove(item);
		}

		public IEnumerable<IServiceOptions> GetInstances() {
			return serviceOptions.ToList();
		}
	}
}
