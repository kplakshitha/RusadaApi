using Business.Services;
using Data.Repositories;

namespace Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAircraftService, AircraftService>();
            services.AddTransient<IFileService, FileService>();

            return services;
        }
    }
}
