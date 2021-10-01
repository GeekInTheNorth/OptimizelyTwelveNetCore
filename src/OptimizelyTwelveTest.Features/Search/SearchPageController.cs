namespace OptimizelyTwelveTest.Features.Search
{
    using Microsoft.AspNetCore.Mvc;
    using OptimizelyTwelveTest.Features.Common;

    public class SearchPageController : PageControllerBase<SearchPage>
    {
        [HttpGet]
        public IActionResult Index(SearchPage currentContent)
        {
            return View(currentContent);
        }

        [HttpGet]
        public IActionResult Search(SearchPage currentContent, string searchText, int page)
        {
            return new ContentResult()
            {
                Content = "{ \"TODO\": \"Create search content\" }",
                ContentType = "application/json",
                StatusCode = 200
            };
        }
    }
}