using System;

using OptimizelyTwelveTest.Features.RobotsHandler.Models;

namespace OptimizelyTwelveTest.Features.RobotsHandler
{
    public interface IRobotsContentRepository
    {
        RobotsEntity Get(Guid siteId);

        void Save(Guid siteId, string robotsContent);
    }
}
