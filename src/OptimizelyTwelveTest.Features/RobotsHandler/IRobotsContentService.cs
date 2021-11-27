using System;

namespace OptimizelyTwelveTest.Features.RobotsHandler
{
    public interface IRobotsContentService
    {
        string GetRobotsContent(string requestPath);

        string GetDefaultRobotsContent(bool includeMessage = false);

        void SaveRobotsContent(Guid siteId, string robotsContent);
    }
}
