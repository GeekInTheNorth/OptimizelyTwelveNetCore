using System;
using System.Linq;

using EPiServer.Web;

using Stott.Optimizely.RobotsHandler.Services;
using Stott.Optimizely.RobotsHandler.UI.ViewModels;

namespace Stott.Optimizely.RobotsHandler.UI
{
    public class RobotsAdminViewModelBuilder : IRobotsAdminViewModelBuilder
    {
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;

        private readonly IRobotsContentService _robotsContentService;

        private Guid? _siteId;

        public RobotsAdminViewModelBuilder(
            ISiteDefinitionRepository siteDefinitionRepository, 
            IRobotsContentService robotsContentService)
        {
            _siteDefinitionRepository = siteDefinitionRepository;
            _robotsContentService = robotsContentService;
        }

        public RobotsAdminViewModel Build()
        {
            var allSites = _siteDefinitionRepository.List();
            var siteId = _siteId ?? allSites?.FirstOrDefault()?.Id;
            var robotsContent = siteId.HasValue ?
                _robotsContentService.GetRobotsContent(siteId.Value) :
                _robotsContentService.GetDefaultRobotsContent(false);

            return new RobotsAdminViewModel
            {
                Sites = allSites.Select(s => new SiteViewModel { SiteId = s.Id, SiteName = s.Name }).ToList(),
                CurrentSiteId = siteId,
                CurrentSiteName = allSites.FirstOrDefault(x => x.Id.Equals(siteId))?.Name,
                CurrentRobotsContent = robotsContent
            };
        }

        public IRobotsAdminViewModelBuilder WithSiteId(Guid? siteId)
        {
            _siteId = siteId;

            return this;
        }
    }
}
