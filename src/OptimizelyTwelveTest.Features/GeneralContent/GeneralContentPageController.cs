namespace OptimizelyTwelveTest.Features.GeneralContent
{
    using Common;
    using Microsoft.AspNetCore.Mvc;

    public class GeneralContentPageController : PageControllerBase<GeneralContentPage>
    {
        public IActionResult Index(GeneralContentPage currentContent)
        {
            return View(currentContent);
        }
    }
}