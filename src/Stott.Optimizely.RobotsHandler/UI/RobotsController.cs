using System;
using System.Linq;

using EPiServer.Logging;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Stott.Optimizely.RobotsHandler.Exceptions;
using Stott.Optimizely.RobotsHandler.Services;

namespace Stott.Optimizely.RobotsHandler.UI
{
    public class RobotsController : Controller
    {
        private readonly IRobotsContentService _service;

        private readonly IRobotsEditViewModelBuilder _editViewModelBuilder;

        private readonly IRobotsListViewModelBuilder _listingViewModelBuilder;

        private readonly IRobotsContentService _robotsContentService;

        private readonly ILogger _logger = LogManager.GetLogger(typeof(RobotsController));

        public RobotsController(
            IRobotsContentService service,
            IRobotsEditViewModelBuilder viewModelBuilder,
            IRobotsListViewModelBuilder listingViewModelBuilder, 
            IRobotsContentService robotsContentService)
        {
            _service = service;
            _editViewModelBuilder = viewModelBuilder;
            _listingViewModelBuilder = listingViewModelBuilder;
            _robotsContentService = robotsContentService;
        }

        [HttpGet]
        [Route("robots.txt")]
        public IActionResult Index()
        {
            try
            {
                var robotsContent = _service.GetRobotsContent(Request.Host.Value);

                return new ContentResult
                {
                    Content = robotsContent,
                    ContentType = "text/plain",
                    StatusCode = 200
                };
            }
            catch (RobotsContentException exception)
            {
                _logger.Error("A custom robots.txt does not exist for the current site.", exception);

                return new ContentResult
                {
                    Content = _service.GetDefaultRobotsContent(true),
                    ContentType = "text/plain",
                    StatusCode = 200
                };
            }
            catch (Exception exception)
            {
                _logger.Error("Failed to load the robots.txt for the current site.", exception);
                throw;
            }
        }

        [HttpGet]
        [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
        [Route("[controller]/[action]")]
        public IActionResult List()
        {
            var model = _listingViewModelBuilder.Build();

            if (model.List.Count == 1)
            {
                var id = model.List.First().Id;

                return RedirectToAction("Edit", new { siteId = id });
            }

            return View("RobotsSiteList", model);
        }

        [HttpGet]
        [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
        [Route("[controller]/[action]")]
        public IActionResult Edit(string siteId)
        {
            if (!Guid.TryParse(siteId, out var siteIdGuid))
            {
                throw new ArgumentException("siteId cannot be parsed as a valid GUID.", nameof(siteId));
            }

            var model = _editViewModelBuilder.WithSiteId(siteIdGuid).Build();

            return Json(model);
        }

        // TODO - Update to work as an AJAX post event.
        ////[HttpPost]
        ////[Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
        ////[Route("[controller]/[action]")]
        ////public IActionResult Edit(RobotsEditViewModel formSubmitModel)
        ////{
        ////    _robotsContentService.SaveRobotsContent(formSubmitModel.SiteId, formSubmitModel.RobotsContent);
        ////
        ////    var model = _editViewModelBuilder.WithSiteId(formSubmitModel.SiteId).Build();
        ////
        ////    return View("RobotsSiteEdit", model);
        ////}
    }
}
