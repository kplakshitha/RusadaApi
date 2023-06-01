using AutoMapper;
using Business.Profiles;

namespace Api.Extensions
{
    public static class AutomapperExtensions
    {
        public static IServiceCollection InjectAutomapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AircraftDetailProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
