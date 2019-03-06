using System;
using System.Collections.Generic;
using System.Text;

namespace Logger {
	public class LogEntryDTO {
		private string _serviceName;

		public string ServiceName {
			get {
				return "LOG_" + this._serviceName;
			}
			set {
				this._serviceName = value;
			}
		}

		public string Message;
	}
}
