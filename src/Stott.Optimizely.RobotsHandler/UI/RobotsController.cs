using System;
using System.Linq;
using System.Net;

using EPiServer.Logging;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Stott.Optimizely.RobotsHandler.Services;
using Stott.Optimizely.RobotsHandler.UI.ViewModels;

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
        public IActionResult Details(string siteId)
        {
            if (!Guid.TryParse(siteId, out var siteIdGuid))
            {
                throw new ArgumentException("siteId cannot be parsed as a valid GUID.", nameof(siteId));
            }

            var model = _editViewModelBuilder.WithSiteId(siteIdGuid).Build();

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
        [Route("[controller]/[action]")]
        public IActionResult Save(RobotsEditViewModel formSubmitModel)
        {
            try
            {
                _robotsContentService.SaveRobotsContent(formSubmitModel.SiteId, formSubmitModel.RobotsContent);

                return new OkResult();
            }
            catch(Exception exception)
            {
                _logger.Error($"Failed to save robots.txt content for {formSubmitModel.SiteName}", exception);
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Content = exception.Message,
                    ContentType = "text/plain"
                };
            }
        }
    }
}
