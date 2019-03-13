using Microsoft.AspNetCore.Http;
using System;

namespace Loadbalancer.Balancer {
	public class ServiceOptions
		: IServiceOptions {
		public ServiceOptions(
			string scheme,
			HostString host,
			PathString pathBase,
			QueryString appendQuery,
			string serviceId) {
			if (string.IsNullOrWhiteSpace(scheme))
				throw new ArgumentNullException(nameof(scheme));
			if (host == null)
				throw new ArgumentNullException(nameof(host));
			if (string.IsNullOrWhiteSpace(serviceId))
				throw new ArgumentNullException(nameof(serviceId));

			Scheme = scheme;
			Host = host;
			PathBase = pathBase;
			AppendQuery = appendQuery;
			ServiceId = serviceId;
		}

		public ServiceOptions(Uri input) {
			this.Scheme = input.Scheme;
			this.Host = HostString.FromUriComponent(input.Host);
			this.PathBase = input.LocalPath;
			this.ServiceId = input.Host;
		}

		public string Scheme { get; }

		public HostString Host { get; }

		public PathString PathBase { get; }

		public QueryString AppendQuery { get; }

		public string ServiceId { get; }
	}
}
