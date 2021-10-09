using Berry.MongoDB;
using Berry.MongoDB.Abstractions;
using Berry.MongoDB.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static void AddMongoDbClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<MongoDbOptions>().Configure(options =>
            {
                configuration.GetSection(nameof(MongoDbOptions)).Bind(options);
            }).ValidateDataAnnotations();

            services.TryAddSingleton<IMongoDbClient, MongoDbClient>();
        }
    }
}
