using System;

using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace OptimizelyTwelveTest.Features.RobotsHandler.Models
{
    public class RobotsEntity : IDynamicData
    {
        public Identity Id { get; set; }

        public Guid SiteId { get; set; }

        public string RobotsContent { get; set; }
    }
}
