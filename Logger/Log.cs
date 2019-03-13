using System;
using EasyNetQ;
using Logger;

namespace Common.Logger {
	public class Log : IDisposable {
		private IBus bus;

		public Log() {
			bus = RabbitHutch.CreateBus("host=ssh.jalawebs.com;username=user;password=user");
		}

		public void Write(string serviceName, string message) {
			this.Write(new LogEntryDTO() { ServiceName = serviceName, Message = message });
		}

		public void Write(LogEntryDTO entry) {
			bus.Publish(entry, "log");
		}

		public void Dispose() {
			bus.Dispose();
		}
	}
}
