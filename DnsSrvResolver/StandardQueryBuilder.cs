using System.Collections.Generic;
using System.Text;
using DnsClient;

namespace DnsSrvResolver
{
  
    public class StandardQueryBuilder : IStandardQueryBuilder
    {
        private readonly string _serviceName;
        private readonly string _tag;
        private readonly string _datacenter;

        public StandardQueryBuilder(string serviceName, string tag = null, string datacenter = null)
        {
            _serviceName = serviceName;
            _tag = tag;
            _datacenter = datacenter;
        }

        public string Scheme { get; set; } = "http";

        public string GetServiceQuery()
        {
            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(_tag))
            {
                builder.Append($"{_tag}.");
            }

            builder.Append($"{_serviceName}.service.");

            if (!string.IsNullOrEmpty(_datacenter))
            {
                builder.Append($"{_datacenter}.");
            }
            
            return builder.ToString().TrimEnd('.');
        }
    }
}