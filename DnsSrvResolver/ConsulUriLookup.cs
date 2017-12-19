using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DnsClient;

namespace DnsSrvResolver
{
    public class ConsulUriLookup
    {

        private Stack<ServiceHostEntry> _entries;
        public ConsulUriLookup(string dnsName)
        {
            var dns = new LookupClient(IPAddress.Loopback, 8500);

            var ary = dns.ResolveService("service.consul", dnsName);

            _entries = new Stack<ServiceHostEntry>(ary);
        }


        public Uri GetNextUri()
        {
           throw new NotImplementedException();
        }
    }
}
