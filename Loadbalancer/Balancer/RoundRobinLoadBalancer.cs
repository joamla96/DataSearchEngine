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
        public IServiceOptions Next()
        {
            throw new NotImplementedException();
        }
    }
}
