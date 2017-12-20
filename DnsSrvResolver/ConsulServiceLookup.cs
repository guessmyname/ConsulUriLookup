using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DnsClient;

namespace DnsSrvResolver
{
    public abstract class ConsulServiceLookup
    {
        protected const string BaseDomain = "service.consul";
        private readonly string _scheme;

        private readonly Lazy<Stack<ServiceHostEntry>> _entries;
        

        protected ConsulServiceLookup()
        {
           _entries = new Lazy<Stack<ServiceHostEntry>>( ()=> ResolveService(GetDnsClient()));
        }
       
        private LookupClient GetDnsClient()
        {
            var dns = new LookupClient(IPAddress.Loopback, 8600);
            return dns;
        }

      protected  abstract Stack<ServiceHostEntry> ResolveService(LookupClient lookupClient);

        public Uri GetNextUri()
        {
          
            if (!_entries.Value.Any()) return null;

            var next = _entries.Value.Pop();
            var builder = new UriBuilder(_scheme,next.HostName,next.Port);
            return builder.Uri;
        }
    }
}
