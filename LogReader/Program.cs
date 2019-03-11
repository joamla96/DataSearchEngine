using System;
using System.Threading.Tasks;
using EasyNetQ;
using Common.Logger;
using System.Threading;

namespace LogReader {
	public class Program {
		private IBus bus;
		private ManualResetEvent _resetEvent = new ManualResetEvent(false);

		public static void Main(string[] args) {
			Console.WriteLine("Hello World!");

			Program p = new Program();
			p.Startup();
		}

		private void Startup() {
			using (bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;username=user;password=user")) {
				// Listen for order request messages from customers
				bus.Subscribe<Logger.LogEntryDTO>("log", (x) => msgReader(x));

				_resetEvent.WaitOne(); // Block thread
			}
		}

		private void msgReader(Logger.LogEntryDTO input) {
			Console.WriteLine("Service: {0} - Message: {1}", input.ServiceName, input.Message);
		}

	}
}
