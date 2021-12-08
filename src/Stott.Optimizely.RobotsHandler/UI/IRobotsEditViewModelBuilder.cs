using System;

using Stott.Optimizely.RobotsHandler.UI.ViewModels;

namespace Stott.Optimizely.RobotsHandler.UI
{
    public interface IRobotsEditViewModelBuilder
    {
        IRobotsEditViewModelBuilder WithSiteId(Guid siteId);

        RobotsEditViewModel Build();
    }
}
