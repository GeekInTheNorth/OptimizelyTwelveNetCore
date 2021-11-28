using System;

namespace Stott.Optimizely.RobotsHandler.Services
{
    public interface IRobotsContentService
    {
        string GetRobotsContent(Guid siteId);

        string GetRobotsContent(string requestPath);

        string GetDefaultRobotsContent(bool includeMessage = false);

        void SaveRobotsContent(Guid siteId, string robotsContent);
    }
}
