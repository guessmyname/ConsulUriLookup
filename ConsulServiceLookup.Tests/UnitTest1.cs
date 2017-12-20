using System;
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
            var lookup = new DnsSrvResolver.StandardConsulLookup("demo-api");

            var service = lookup.GetNextUri();

            Assert.IsType<Uri>(service);

            Console.WriteLine(service.ToString());
        }
    }
}
