using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Loadbalancer.Balancer {
	public class MessageHandler {
		private ManualResetEvent _resetEvent = new ManualResetEvent(false);

		private ILoadBalancer loadBalancer;
		private IBus bus;

		// TODO Handle disconnected instances

		public MessageHandler(ILoadBalancer loadBalancer) {
			this.loadBalancer = loadBalancer;
			Task.Factory.StartNew(Start);
		}

		private void Start() {
			using (bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;persistentMessages=false")) {
				// Listen for order request messages from customers
				bus.Receive<IServiceOptions>("DataSearchContainInstances", input => OnNewInstance(input));

				_resetEvent.WaitOne(); // Block thread
			}
		}

		private void OnNewInstance(IServiceOptions instance) {
			loadBalancer.AddInstance(instance);
		}

		private void OnInstanceDC(string serviceId) {
			var service = loadBalancer.GetInstances().First(x => x.ServiceId == serviceId);
			loadBalancer.RemoveInstance(service);
		}
	}
}
