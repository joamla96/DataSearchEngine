using EasyNetQ;
using RestSharp;
﻿using Common.Logger;
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

		private Log Log;



		public MessageHandler(ILoadBalancer loadBalancer, Log log) {
			this.loadBalancer = loadBalancer;
			this.Log = log;

			Task.Factory.StartNew(Start);
			Task.Factory.StartNew(InstanceDCHandler);

		}

		private void Start() {
			using (bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;username=user;password=user")) {
				// Listen for order request messages from customers
				bus.Receive<Uri>("DataSearchContainInstances", input => OnNewInstance(input));

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

		private void OnNewInstance(Uri instanceUri) {
			var instance = new ServiceOptions(instanceUri);

			Log.Write("loadbalancer", String.Format("Instance {0} came alive", instance.ServiceId));
			loadBalancer.AddInstance(instance);
		}


		private void OnInstanceDC(IServiceOptions service) {
			Log.Write("loadbalancer", String.Format("Instance {0} died", service.ServiceId));
			loadBalancer.RemoveInstance(service);
		}
	}
}
