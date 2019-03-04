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
		private IBus bus;
		private ManualResetEvent _resetEvent = new ManualResetEvent(false);

		public RoundRobinLoadBalancer()
		{
			Task.Factory.StartNew(Start);
		}

		private void Start()
		{
			using (bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;persistentMessages=false"))
			{

				// Listen for order request messages from customers
				bus.Receive<IServiceOptions>("DataSearchContainInstances", input => OnNewInstance(input));

				_resetEvent.WaitOne(); // Block thread
			}
		}

		private void OnNewInstance(IServiceOptions instance)
		{
			this.serviceOptions.Add(instance);
		}

		private void OnInstanceDC(string serviceId)
		{
			var service = serviceOptions.First(x => x.ServiceId == serviceId);
			serviceOptions.Remove(service);
		}

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
		public void AddItem(IServiceOptions item)
		{
			serviceOptions.Add(item);
		}

		/// <summary>
		/// Remove item from the list of possible services
		/// </summary>
		/// <param name="item">item to remove</param>
		public void RemoveItem(IServiceOptions item)
		{
			serviceOptions.Remove(item);
		}
	}
}
