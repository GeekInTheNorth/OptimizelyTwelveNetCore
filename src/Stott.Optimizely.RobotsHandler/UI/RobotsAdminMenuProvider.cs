using System.Collections.Generic;

using EPiServer.Shell.Navigation;

namespace Stott.Optimizely.RobotsHandler.UI
{
    [MenuProvider]
    public class RobotsAdminMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Robots", "/global/cms/admin/stott.optimizely.robots", "/Robots/List")
            {
                IsAvailable = context => true,
                SortIndex = 100
            };

            return new List<MenuItem>(1)
            {
                adminModule
            };
        }
    }
}
