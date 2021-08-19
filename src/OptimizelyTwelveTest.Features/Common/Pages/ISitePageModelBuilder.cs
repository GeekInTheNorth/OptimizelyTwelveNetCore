namespace OptimizelyTwelveTest.Features.Common.Pages
{
    public interface ISitePageModelBuilder<T> where T : SitePageData
    {
        ISitePageModelBuilder<T> WithContent(T sitePageData);

        ISitePageModel<T> Build();
    }
}