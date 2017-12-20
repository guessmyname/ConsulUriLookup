using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DnsClient;

namespace DnsSrvResolver
{
    public class ConsulServiceLookup
    {
        private readonly IStandardQueryBuilder _queryBuilder;
        protected const string BaseDomain = "consul";
        private readonly string _scheme;

        private readonly Lazy<Stack<ServiceHostEntry>> _entries;


        public ConsulServiceLookup(IStandardQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
            _scheme = queryBuilder.Scheme;
            _entries = new Lazy<Stack<ServiceHostEntry>>( ()=> ResolveService(GetDnsClient()));
        }
       
        private LookupClient GetDnsClient()
        {
            var dns = new LookupClient(IPAddress.Loopback, 8600);
            return dns;
        }

        public Uri GetNextUri()
        {
          
            if (!_entries.Value.Any()) return null;

            var next = _entries.Value.Pop();
            var builder = new UriBuilder(_scheme,next.HostName,next.Port);
            return builder.Uri;
        }

        protected virtual Stack<ServiceHostEntry> ResolveService(LookupClient lookupClient)
        {
            var serviceQuery = _queryBuilder.GetServiceQuery();
            var ary = lookupClient.ResolveService(BaseDomain, serviceQuery);

            return new Stack<ServiceHostEntry>(ary);
        }
    }
}
