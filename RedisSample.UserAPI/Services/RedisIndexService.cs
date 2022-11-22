using Redis.OM;
using RedisSample.UserAPI.Models;

namespace RedisSample.UserAPI.Services
{
    public class RedisIndexService : IHostedService
    {
        private readonly RedisConnectionProvider _provider;

        public RedisIndexService(RedisConnectionProvider provider)
        {
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            var info = (await _provider.Connection.ExecuteAsync("FT._LIST")).ToArray().Select(x => x.ToString());
            if (!info.Any(x => x == "user-idx"))
            {
                await _provider.Connection.CreateIndexAsync(typeof(User));
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
