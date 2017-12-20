using System.Collections.Generic;
using DnsClient;

namespace DnsSrvResolver
{
    public class StandardConsulLookup : ConsulServiceLookup
    {
        private readonly string _serviceName;

        public StandardConsulLookup(string serviceName)
        {
            _serviceName = serviceName;
        }


        protected override Stack<ServiceHostEntry> ResolveService(LookupClient lookupClient)
        {
            var ary = lookupClient.ResolveService(BaseDomain, _serviceName);

            return new Stack<ServiceHostEntry>(ary);
        }
    }
}