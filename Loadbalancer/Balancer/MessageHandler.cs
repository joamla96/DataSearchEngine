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
			//Log.Write("loadbalancer_hc", "Executing HealthCheck");
			var serviceOptions = loadBalancer.GetInstances();

			foreach(var option in serviceOptions) {
				if(!this.Healthcheck(option))
				{
					OnInstanceDC(option);
				}
			}
		}

		private bool Healthcheck(Uri option)
		{
			Log.Write("loadbalancer_hc", "Checking " + option.Host);
			string basePath = option.Scheme + "://" + option.Host + ":" + option.Port;
			var client = new RestClient(basePath);
			client.Timeout = 3000;
			var request = new RestRequest("api/Healthcheck", Method.GET);

			var result = client.Execute(request);

			if (!result.IsSuccessful)
			{
				Log.Write("loadbalancer_hc", option.Host + " timed out.");
				return false;
			}

			Log.Write("loadbalancer_hc", option.Host + " is still alive.");
			return true;
		}

		private void OnNewInstance(Uri instance) {

			if(!this.Healthcheck(instance))
			{
				Thread.Sleep(5000);
				if (!this.Healthcheck(instance))
					return;
			}

			Log.Write("loadbalancer", String.Format("Instance {0} came alive", instance.Host));
			loadBalancer.AddInstance(instance);
		}


		private void OnInstanceDC(Uri service) {
			Log.Write("loadbalancer", String.Format("Instance {0} died", service.Host));
			loadBalancer.RemoveInstance(service);
		}
	}
}
