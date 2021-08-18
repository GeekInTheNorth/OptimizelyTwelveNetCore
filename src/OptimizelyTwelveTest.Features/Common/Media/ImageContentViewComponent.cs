namespace OptimizelyTwelveTest.Features.Common.Media
{
    using EPiServer.Web.Mvc;
    using Microsoft.AspNetCore.Mvc;

    public class ImageContentViewComponent : PartialContentComponent<ImageContent>
    {
        public override IViewComponentResult Invoke(ImageContent currentContent)
        {
            return View(currentContent);
        }
    }
}
