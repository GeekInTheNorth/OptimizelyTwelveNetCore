using System;

using EPiServer.Data;
using EPiServer.Data.Dynamic;

using OptimizelyTwelveTest.Features.RobotsHandler.Models;

namespace OptimizelyTwelveTest.Features.RobotsHandler
{
    public class RobotsContentRepository : IRobotsContentRepository
    {
        private readonly DynamicDataStore store;

        public RobotsContentRepository()
        {
            store = DynamicDataStoreFactory.Instance.CreateStore(typeof(RobotsEntity));
        }

        public RobotsEntity Get(Guid siteId)
        {
            return store.Load<RobotsEntity>(Identity.NewIdentity(siteId));
        }

        public void Save(Guid siteId, string robotsContent)
        {
            var recordToSave = Get(siteId);
            if (recordToSave == null)
            {
                recordToSave = new RobotsEntity
                {
                    Id = Identity.NewIdentity(siteId),
                    SiteId = siteId,
                    RobotsContent = robotsContent
                };
            }

            recordToSave.RobotsContent = robotsContent;

            store.Save(recordToSave);
        }
    }
}
