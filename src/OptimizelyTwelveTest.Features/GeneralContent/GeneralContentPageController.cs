namespace OptimizelyTwelveTest.Features.GeneralContent
{
    using Common;

    using Microsoft.AspNetCore.Mvc;

    using OptimizelyTwelveTest.Features.Common.Pages;

    public class GeneralContentPageController : PageControllerBase<GeneralContentPage>
    {
        private readonly ISitePageModelBuilder<GeneralContentPage> _modelBuilder;

        public GeneralContentPageController(ISitePageModelBuilder<GeneralContentPage> modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public IActionResult Index(GeneralContentPage currentContent)
        {
            var model = _modelBuilder.WithContent(currentContent).Build();

            return View(model);
        }
    }
}