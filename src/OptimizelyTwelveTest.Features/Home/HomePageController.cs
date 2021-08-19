namespace OptimizelyTwelveTest.Features.Home
{
    using Microsoft.AspNetCore.Mvc;

    using OptimizelyTwelveTest.Features.Common;
    using OptimizelyTwelveTest.Features.Common.Pages;

    public class HomePageController : PageControllerBase<HomePage>
    {
        private readonly ISitePageModelBuilder<HomePage> _modelBuilder;

        public HomePageController(ISitePageModelBuilder<HomePage> modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public IActionResult Index(HomePage currentPage)
        {
            var model = _modelBuilder.WithContent(currentPage).Build();

            return View(model);
        }
    }
}