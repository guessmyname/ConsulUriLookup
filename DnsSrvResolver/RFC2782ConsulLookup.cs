using System.Collections.Generic;
using DnsClient;

namespace DnsSrvResolver
{
    public class RFC2782ConsulLookup : ConsulServiceLookup
    {
        private readonly string _serviceName;
        private readonly string _servceProtocol;

        public RFC2782ConsulLookup(string serviceName, string servceProtocol)
        {
            _serviceName = serviceName;
            _servceProtocol = servceProtocol;
        }
        protected override Stack<ServiceHostEntry> ResolveService(LookupClient lookupClient)
        {
            var ary = lookupClient.ResolveService(BaseDomain, _serviceName, _servceProtocol);

            return new Stack<ServiceHostEntry>(ary);
        }
    }
}