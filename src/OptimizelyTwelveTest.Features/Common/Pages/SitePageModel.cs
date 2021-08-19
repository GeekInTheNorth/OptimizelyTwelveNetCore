namespace OptimizelyTwelveTest.Features.Common.Pages
{
    public class SitePageModel<T> : ISitePageModel<T>
        where T : SitePageData
    {
        public SitePageModel(T sitePageData)
        {
            Content = sitePageData;

        }

        public T Content { get; set; }

        public SitePageMetaDataModel MetaData { get; set; }
    }
}