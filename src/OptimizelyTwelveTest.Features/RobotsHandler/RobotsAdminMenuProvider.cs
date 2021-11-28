using System.Collections.Generic;

using EPiServer.Shell.Navigation;

namespace OptimizelyTwelveTest.Features.RobotsHandler
{
    [MenuProvider]
    public class RobotsAdminMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Robots", "/global/cms/stottcode.robots", "/Robots/Admin")
            {
                IsAvailable = context => true,
                SortIndex = 100
            };

            var robotsAdminItem = new UrlMenuItem("Robots.txt Admin", "/global/cms/stottcode.robots/robots", "/Robots/Admin")
            {
                IsAvailable = context => true,
                SortIndex = 101
            };

            return new List<MenuItem>(2)
            {
                adminModule,
                robotsAdminItem
            };
        }
    }
}
