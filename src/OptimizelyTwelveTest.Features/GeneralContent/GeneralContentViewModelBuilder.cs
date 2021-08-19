namespace OptimizelyTwelveTest.Features.GeneralContent
{
    using EPiServer.Web.Routing;

    using OptimizelyTwelveTest.Features.Common.Pages;
    using OptimizelyTwelveTest.Features.Settings;

    public class GeneralContentViewModelBuilder : SitePageModelBuilder<GeneralContentPage>, ISitePageModelBuilder<GeneralContentPage>
    {
        public GeneralContentViewModelBuilder(ISiteSettings siteSettings, UrlResolver urlResolver) : base(siteSettings, urlResolver)
        {
        }
    }
}