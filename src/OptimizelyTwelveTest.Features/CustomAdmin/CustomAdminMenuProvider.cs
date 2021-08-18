namespace OptimizelyTwelveTest.Features.CustomAdmin
{
    using System.Collections.Generic;
    using EPiServer.Shell.Navigation;

    [MenuProvider]
    public class CustomAdminMenuProvider : IMenuProvider
    {
        public IEnumerable<MenuItem> GetMenuItems()
        {
            var adminModule = new UrlMenuItem("Custom Admin Module", "/global/cms/customadmin", "/CustomAdminPage/Index");
            adminModule.IsAvailable = context => true;
            adminModule.SortIndex = 100;
            var urlMenuItem1 = new UrlMenuItem("Custom Admin Page 1", "/global/cms/customadmin/pageone", "/CustomAdminPage/FunctionOne");
            urlMenuItem1.IsAvailable = context => true;
            urlMenuItem1.SortIndex = 100;
            var urlMenuItem2 = new UrlMenuItem("Custom Admin Page 2", "/global/cms/customadmin/pagetwo", "/CustomAdminPage/FunctionTwo");
            urlMenuItem2.IsAvailable = context => true;
            urlMenuItem2.SortIndex = 100;

            return new List<MenuItem>(1)
            {
                adminModule,
                urlMenuItem1,
                urlMenuItem2
            };
        }
    }
}