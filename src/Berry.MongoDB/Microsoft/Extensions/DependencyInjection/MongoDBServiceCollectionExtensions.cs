using Berry.MongoDB.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Berry.MongoDB.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// MongoDBServiceCollectionExtensions
    /// </summary>
    public static class MongoDBServiceCollectionExtensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDbClient(configuration);

            services.TryAddTransient(typeof(IMongoDbRepository<>), typeof(MongoDbRepository<>));
        }
    }
}
