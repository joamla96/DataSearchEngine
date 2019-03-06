using EasyNetQ;
using RestSharp;
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
			Task.Factory.StartNew(InstanceDCHandler);
		}

		private void Start() {
			using (bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;persistentMessages=false")) {
				// Listen for order request messages from customers
				bus.Receive<IServiceOptions>("DataSearchContainInstances", input => OnNewInstance(input));

				_resetEvent.WaitOne(); // Block thread
			}
		}

		private void InstanceDCHandler() {
			while(true) {
				Thread.Sleep(1500);
				ExecuteHealthCheck();
			}
		}

		private void ExecuteHealthCheck() {
			var serviceOptions = loadBalancer.GetInstances();

			Parallel.ForEach(serviceOptions, (option) => {
				var client = new RestClient(new Uri(option.Host.ToUriComponent()));
				var request = new RestRequest("Healthcheck", Method.GET);

				var result = client.Execute(request);

				if (result.ResponseStatus == ResponseStatus.TimedOut)
					OnInstanceDC(option);
			});
		}

		private void OnNewInstance(IServiceOptions instance) {
			loadBalancer.AddInstance(instance);
		}

		private void OnInstanceDC(IServiceOptions service) {
			loadBalancer.RemoveInstance(service);
		}
	}
}
