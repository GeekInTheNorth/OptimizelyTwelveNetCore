﻿using System;
using System.Linq;

using EPiServer.Web;

using Stott.Optimizely.RobotsHandler.Services;
using Stott.Optimizely.RobotsHandler.UI.ViewModels;

namespace Stott.Optimizely.RobotsHandler.UI
{
    public class RobotsEditViewModelBuilder : IRobotsEditViewModelBuilder
    {
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;

        private readonly IRobotsContentService _robotsContentService;

        private Guid _siteId;

        public RobotsEditViewModelBuilder(
            ISiteDefinitionRepository siteDefinitionRepository, 
            IRobotsContentService robotsContentService)
        {
            _siteDefinitionRepository = siteDefinitionRepository;
            _robotsContentService = robotsContentService;
            _siteId = Guid.Empty;
        }

        public RobotsEditViewModel Build()
        {
            if (_siteId == Guid.Empty)
            {
                throw new Exception("oops");
            }

            var allSites = _siteDefinitionRepository.List();
            var selectedSite = allSites.FirstOrDefault(x => x.Id.Equals(_siteId));
            var robotsContent = _robotsContentService.GetRobotsContent(_siteId);

            return new RobotsEditViewModel
            {
                SiteId = selectedSite.Id,
                SiteName = selectedSite.Name,
                RobotsContent = robotsContent
            };
        }

        public IRobotsEditViewModelBuilder WithSiteId(Guid siteId)
        {
            _siteId = siteId;

            return this;
        }
    }
}
