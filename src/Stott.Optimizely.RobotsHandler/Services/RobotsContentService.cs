using System;
using System.Linq;
using System.Text;

using EPiServer.Web;

using Stott.Optimizely.RobotsHandler.Exceptions;

namespace Stott.Optimizely.RobotsHandler.Services
{
    public class RobotsContentService : IRobotsContentService
    {
        private readonly ISiteDefinitionRepository siteDefinitionRepository;

        private readonly IRobotsContentRepository robotsContentRepository;

        public RobotsContentService(
            ISiteDefinitionRepository siteDefinitionRepository,
            IRobotsContentRepository robotsContentRepository)
        {
            this.siteDefinitionRepository = siteDefinitionRepository;
            this.robotsContentRepository = robotsContentRepository;
        }

        public string GetDefaultRobotsContent(bool includeMessage = false)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("User-agent: *");
            stringBuilder.AppendLine("Disallow: /episerver/");
            stringBuilder.AppendLine("Disallow: /utils/");

            if (includeMessage)
            {
                stringBuilder.AppendLine(string.Empty);
                stringBuilder.AppendLine("# This version has been generated automatically.");
            }

            return stringBuilder.ToString();
        }

        public string GetRobotsContent(string requestHost)
        {
            var site = GetCurrentSite(requestHost);
            if (site == null)
            {
                throw new RobotsContentException($"Cannot resolve CMS site from the request host: {requestHost}");
            }

            var robots = robotsContentRepository.Get(site.Id);
            if (robots == null)
            {
                throw new RobotsContentException($"Robots.txt has not been defined for the current host: {requestHost}");
            }

            return robots.RobotsContent;
        }

        public void SaveRobotsContent(Guid siteId, string robotsContent)
        {
            if (!Guid.Empty.Equals(siteId))
            {
                throw new ArgumentException($"{nameof(siteId)} is not a non-null non-empty value.", nameof(siteId));
            }

            var existingSite = siteDefinitionRepository.Get(siteId);
            if (existingSite == null)
            {
                throw new ArgumentException($"{nameof(siteId)} does not correlate to a known site.", nameof(siteId));
            }

            robotsContentRepository.Save(existingSite.Id, robotsContent);
        }

        private SiteDefinition GetCurrentSite(string requestHost)
        {
            var sites = siteDefinitionRepository.List();

            return sites.FirstOrDefault(s => s.Hosts.Any(h => h.Name.Contains(requestHost, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
