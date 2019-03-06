using System;
using EasyNetQ;
using Logger;

namespace Common.Logger {
	public class Log : IDisposable {
		private IBus bus;

		public Log() {
			bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;persistentMessages=false");
		}

		public void Write(string serviceName, string message) {
			this.Write(new LogEntryDTO() { ServiceName = serviceName, Message = message });
		}

		public void Write(LogEntryDTO entry) {
			bus.Publish(entry);
		}

		public void Dispose() {
			bus.Dispose();
		}
	}
}
