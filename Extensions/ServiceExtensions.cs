using Microsoft.Extensions.DependencyInjection;
using MongoDB.Database;
using MongoDB.Database.Models;
using MongoDB.Manager;
using MongoDB.Repository;

namespace MongoDB.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUserRepository<Club>, UserRepository>();
            services.AddScoped<IPostRepository<Evenement>, PostRepository>();
            services.AddScoped<IEcoleRepository<Ecole>, EcoleRepository>();
            services.AddScoped<IUniversiteRepository<Universite>, UniversiteRepository>();
            services.AddScoped<IAdministrationRepository<Administration>, AdministrationRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IDomaineRepository<Domaine>, DomaineRepository>();

            return services;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IAccountManager<Club>, AccountManager>();

            return services;
        }
    }
}
