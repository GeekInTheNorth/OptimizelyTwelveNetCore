namespace OptimizelyTwelveTest.Features.Home
{
    using EPiServer.Web.Routing;

    using OptimizelyTwelveTest.Features.Common.Pages;
    using OptimizelyTwelveTest.Features.Settings;

    public class HomePageViewModelBuilder : SitePageModelBuilder<HomePage>, ISitePageModelBuilder<HomePage>
    {
        public HomePageViewModelBuilder(ISiteSettings siteSettings, UrlResolver urlResolver) : base(siteSettings, urlResolver)
        {
        }
    }
}