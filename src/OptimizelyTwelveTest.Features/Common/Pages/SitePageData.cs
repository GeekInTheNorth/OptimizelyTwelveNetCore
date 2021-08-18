namespace OptimizelyTwelveTest.Features.Common.Pages
{
    using System.ComponentModel.DataAnnotations;
    using EPiServer.Core;
    using EPiServer.Web;

    public class SitePageData : PageData
    {
        [Display(
            Name = "Teaser Title",
            Description = "A teaser title to use when rendering as a block",
            GroupName = GroupNames.Teaser,
            Order = 700)]
        public virtual string TeaserTitle { get; set; }

        [Display(
            Name = "Teaser Text",
            Description = "Teaser text to use when rendering as a block",
            GroupName = GroupNames.Teaser,
            Order = 701)]
        public virtual string TeaserText { get; set; }

        [Display(
            Name = "Teaser Image",
            Description = "The image to use when rendering as a block",
            GroupName = GroupNames.Teaser,
            Order = 702)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference TeaserImage { get; set; }
    }
}
