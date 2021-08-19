namespace OptimizelyTwelveTest.Features.Common.Pages
{
    public interface ISitePageModel
    {
        SitePageMetaDataModel MetaData { get; set; }
    }

    public interface ISitePageModel<T> : ISitePageModel
        where T : SitePageData
    {
        T Content { get; set; }
    }
}