using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loadbalancer.Balancer
{
    public class RoundRobinLoadBalancer
        : ILoadBalancer
    {
        //TODO
        //make list of IServiceOptions 
        //Add and remove functions to the list

        //TODO
        //get a pointer to to check where we were last
        //move the pointer one everytime function is called
        //make sure we don't reach a point were we can't get and serviceOption
        //retrun from the list
		private List<IServiceOptions> serviceOptions = new List<IServiceOptions>();
		private int lastRequest = 0;
        public IServiceOptions Next()
        {
            if(serviceOptions.Count == 0) 
				throw new Exception("No Service Options Defined"); // TODO Custom Exception

			++lastRequest;
			if (lastRequest > serviceOptions.Count)
				lastRequest = 0;

			return serviceOptions[lastRequest];
			
        }

		public void AddItem(IServiceOptions item) {
			serviceOptions.Add(item);
		}

		public void RemoveItem(IServiceOptions item) {
			serviceOptions.Remove(item);
		}
    }
}
