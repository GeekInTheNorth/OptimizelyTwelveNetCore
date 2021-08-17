namespace OptimizelyTwelveTest.Features.Home
{
    using OptimizelyTwelveTest.Features.Common;

    using Microsoft.AspNetCore.Mvc;

    public class HomePageController : PageControllerBase<HomePage>
    {
        public IActionResult Index(HomePage currentPage)
        {
            return View(currentPage);
        }
    }
}