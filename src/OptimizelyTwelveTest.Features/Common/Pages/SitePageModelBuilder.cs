namespace OptimizelyTwelveTest.Features.Common.Pages
{
    using EPiServer.Web.Routing;

    using OptimizelyTwelveTest.Features.Settings;

    public abstract class SitePageModelBuilder<T> : ISitePageModelBuilder<T> 
        where T : SitePageData
    {
        private readonly ISiteSettings _siteSettings;
        private readonly UrlResolver _urlResolver;

        private ISitePageModel<T> _model = null;

        protected SitePageModelBuilder(ISiteSettings siteSettings, UrlResolver urlResolver)
        {
            _siteSettings = siteSettings;
            _urlResolver = urlResolver;
        }

        public ISitePageModelBuilder<T> WithContent(T sitePageData)
        {
            _model = new SitePageModel<T>(sitePageData);

            return this;
        }

        public ISitePageModel<T> Build()
        {
            _model.MetaData = new SitePageMetaDataModel();
            if (_model.Content is SitePageData sitePageData)
            {
                _model.MetaData.Title = $"{_siteSettings?.SiteName} | {sitePageData.MetaTitle}";
                _model.MetaData.Description = sitePageData.MetaText;
                _model.MetaData.Image = _urlResolver.GetUrl(sitePageData.MetaImage);
            }
            else
            {
                _model.MetaData.Title = $"{_siteSettings?.SiteName} |";
            }

            return _model;
        }
    }
}