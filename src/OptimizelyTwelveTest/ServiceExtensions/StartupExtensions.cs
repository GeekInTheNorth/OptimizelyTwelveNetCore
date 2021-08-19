namespace OptimizelyTwelveTest.ServiceExtensions
{
    using EPiServer;
    using EPiServer.Core;

    using Features.Home;
    using Features.Settings;

    using Microsoft.Extensions.DependencyInjection;
    using OptimizelyTwelveTest.Features.Common.Pages;
    using OptimizelyTwelveTest.Features.GeneralContent;

    public static class ServiceExtensions
    {
        public static void AddCustomDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISiteSettings>(provider =>
            {
                if (provider.GetService(typeof(IContentLoader)) is IContentLoader contentLoader &&
                    contentLoader.TryGet<HomePage>(ContentReference.StartPage, out var homePage) &&
                    contentLoader.TryGet<SiteSettingsPage>(homePage.SiteSettings, out var siteSettingsPage))
                {
                    return siteSettingsPage;
                }

                return null;
            });
        }

        public static void AddPageBuilders(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISitePageModelBuilder<HomePage>, HomePageViewModelBuilder>();
            serviceCollection.AddScoped<ISitePageModelBuilder<GeneralContentPage>, GeneralContentViewModelBuilder>();
        }
    }
}
