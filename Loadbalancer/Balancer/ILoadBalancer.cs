using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loadbalancer.Balancer
{
    public interface ILoadBalancer
    {
        /// <summary>
        /// Returns the service, which should be the next service
        /// to receive an request.
        /// </summary>
        /// <returns></returns>
        IServiceOptions Next();

		/// <summary>
		/// Add a service to the load balancer
		/// </summary>
		/// <param name="item">The service to add</param>
		void AddItem(IServiceOptions item);


		/// <summary>
		/// Remove a service from the load balancer
		/// </summary>
		/// <param name="item">The item to remove</param>
		void RemoveItem(IServiceOptions item);
    }
}
