using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;

        public NetworkServiceTests()
        {
            _pingService = new NetworkService();
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            var result = _pingService.SendPing();

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Succes: Ping Sent!");
            result.Should().Contain("Succes", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            var pingService = new NetworkService();

            var result = pingService.PingTimeout(a, b);

            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnString()
        {
            var result = _pingService.LastPingDate();

            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            var result = _pingService.GetPingOptions();
            
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnsObject()
        {
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            var result = _pingService.MostRecentPings();

            //result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
