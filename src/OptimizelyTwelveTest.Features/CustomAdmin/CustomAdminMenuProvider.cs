namespace OptimizelyTwelveTest.Features.CustomAdmin
{
    using System.Collections.Generic;

    using EPiServer.Shell.Navigation;

    [MenuProvider]
    public class CustomAdminMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Custom Admin Module", "/global/cms/customadmin", "/CustomAdminPage/Index")
            {
                IsAvailable = context => true,
                SortIndex = 100
            };
            
            var urlMenuItem1 = new UrlMenuItem("Custom Admin Page 1", "/global/cms/customadmin/pageone", "/CustomAdminPage/FunctionOne")
            {
                IsAvailable = context => true,
                SortIndex = 101
            };

            var urlMenuItem2 = new UrlMenuItem("Custom Admin Page 2", "/global/cms/customadmin/pagetwo", "/CustomAdminPage/FunctionTwo")
            {
                IsAvailable = context => true,
                SortIndex = 102
            };

            return new List<MenuItem>(1)
            {
                adminModule,
                urlMenuItem1,
                urlMenuItem2
            };
        }
    }
}