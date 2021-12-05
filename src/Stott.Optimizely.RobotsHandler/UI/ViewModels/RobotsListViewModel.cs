using System;
using System.Collections.Generic;

namespace Stott.Optimizely.RobotsHandler.UI.ViewModels
{
    public class RobotsListViewModel
    {
        public List<RobotsListItemViewModel> List { get; set; }
    }

    public class RobotsListItemViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
