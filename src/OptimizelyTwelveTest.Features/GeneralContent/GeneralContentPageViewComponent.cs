namespace OptimizelyTwelveTest.Features.GeneralContent
{
    using EPiServer.Web.Mvc;
    using Microsoft.AspNetCore.Mvc;

    public class GeneralContentPageViewComponent : PartialContentComponent<GeneralContentPage>
    {
        public override IViewComponentResult Invoke(GeneralContentPage currentContent)
        {
            return View(currentContent);
        }
    }
}