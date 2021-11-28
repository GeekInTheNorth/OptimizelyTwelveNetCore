using System;

using Stott.Optimizely.RobotsHandler.UI.ViewModels;

namespace Stott.Optimizely.RobotsHandler.UI
{
    public interface IRobotsAdminViewModelBuilder
    {
        IRobotsAdminViewModelBuilder WithSiteId(Guid? siteId);

        RobotsAdminViewModel Build();
    }
}
