﻿namespace OptimizelyTwelveTest.Features.Home
{
    using System.ComponentModel.DataAnnotations;
    
    using EPiServer.Core;
    using EPiServer.DataAbstraction;
    using EPiServer.DataAnnotations;
    using EPiServer.Web;

    [ContentType(
        DisplayName = "Home Page",
        GUID = "060C7B3A-971D-4632-92C4-B493C2DA8D52",
        Description = "A page designed as a default landing page.",
        GroupName = SystemTabNames.Content)]
    public class HomePage : PageData
    {
        [Display(
            Name = "Hero Image",
            Description = "The image to render at the top of the page",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference HeroImage { get; set; }

        [Display(
            Name = "Heading",
            Description = "The H1 to display",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string Heading { get; set; }

        [Display(
            Name = "Main Content Area",
            Description = "Renders blocks within the main content section of the home page.",
            GroupName = SystemTabNames.Content, 
            Order = 30)]
        public virtual ContentArea MainContentArea { get; set; }
    }
}
