using System;
using System.Collections.Generic;

namespace Stott.Optimizely.RobotsHandler.UI.ViewModels
{
    public class RobotsAdminViewModel
    {
        public List<SiteViewModel> Sites { get; set; }

        public Guid? CurrentSiteId { get; set; }

        public string CurrentSiteName { get; set; }

        public string CurrentRobotsContent { get; set; }
    }
}
