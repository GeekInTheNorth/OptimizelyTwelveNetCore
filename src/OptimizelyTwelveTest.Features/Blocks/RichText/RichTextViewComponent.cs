namespace OptimizelyTwelveTest.Features.Blocks.RichText
{
    using EPiServer.Web.Mvc;
    using Microsoft.AspNetCore.Mvc;

    public class RichTextBlockViewComponent : BlockComponent<RichTextBlock>
    {
        public override IViewComponentResult Invoke(RichTextBlock currentBlock)
        {
            return View(currentBlock);
        }
    }
}