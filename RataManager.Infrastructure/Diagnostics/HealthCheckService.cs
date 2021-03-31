using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace RataManager.Infrastructure.Diagnostics
{
    public class HealthCheckService : IHealthCheck
    {
        private readonly string _host;
        private readonly int _timeout;

        public HealthCheckService(string host, int timeout)
        {
            _host = host;
            _timeout = timeout;
        }

        /// <inheritdoc />
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync(_host);

                    switch (reply.Status)
                    {
                        case IPStatus.Success:
                            var msg = $"IMCP to {_host} took {reply.RoundtripTime} ms.";

                            return (reply.RoundtripTime > _timeout)
                                ? HealthCheckResult.Degraded(msg)
                                : HealthCheckResult.Healthy(msg);

                        default:
                            var err = $"IMCP to {_host} failed: {reply.Status}";
                            return HealthCheckResult.Unhealthy(err);
                    }
                }
            }
            catch (Exception e)
            {
                var err = $"IMCP to {_host} failed: {e.Message}";

                return HealthCheckResult.Unhealthy(err);
            }
        }
    }
}