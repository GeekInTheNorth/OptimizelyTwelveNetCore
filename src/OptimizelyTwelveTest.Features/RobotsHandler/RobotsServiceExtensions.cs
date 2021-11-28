using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace OptimizelyTwelveTest.Features.RobotsHandler
{
    public static class ServiceExtensions
    {
        public static void AddRobotsHandler(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IRobotsContentService, RobotsContentService>();
            serviceCollection.AddTransient<IRobotsContentRepository, RobotsContentRepository>();
        }
    }
}
