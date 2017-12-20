using System;
using System.Diagnostics;
using System.Net;
using Xunit;
using DnsSrvResolver;

namespace ConsulServiceLookup.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void StandardConsulLookup()
        {
            var queryBuild = new StandardQueryBuilder("demo-api");
            var lookup = new DnsSrvResolver.ConsulServiceLookup(queryBuild);

            var service = lookup.GetNextUri();

            Assert.IsType<Uri>(service);
            
            Debug.WriteLine(service.ToString());
        }
    }
}
