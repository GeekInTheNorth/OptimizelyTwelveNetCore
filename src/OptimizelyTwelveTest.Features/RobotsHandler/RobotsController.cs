using System;

using EPiServer.Logging;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OptimizelyTwelveTest.Features.RobotsHandler.Exceptions;

namespace OptimizelyTwelveTest.Features.RobotsHandler
{
    public class RobotsController : Controller
    {
        private readonly IRobotsContentService _service;

        private readonly ILogger _logger = LogManager.GetLogger(typeof(RobotsController));

        public RobotsController(IRobotsContentService service)
        {
            _service = service;
        }

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
            catch(RobotsContentException exception)
            {
                _logger.Error("A custom robots.txt does not exist for the current site.", exception);

                return new ContentResult
                {
                    Content = _service.GetDefaultRobotsContent(true),
                    ContentType = "text/plain",
                    StatusCode = 200
                };
            }
            catch(Exception exception)
            {
                _logger.Error("Failed to load the robots.txt for the current site.", exception);
                throw;
            }
        }

        [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
        [Route("[controller]/[action]")]
        public IActionResult Admin()
        {
            return View("RobotsAdmin");
        }
    }
}
