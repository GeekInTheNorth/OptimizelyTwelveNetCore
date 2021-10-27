namespace OptimizelyTwelveTest.Features.CustomAdmin
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using OptimizelyTwelveTest.Features.Security;

    [Authorize(Roles = "CmsAdmin,WebAdmins,Administrators")]
    [Route("[controller]")]
    [SecurityHeaderAction]
    public class CustomAdminPageController : Controller
    {
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult FunctionOne()
        {
            return View("Index");
        }

        [Route("[action]")]
        public IActionResult FunctionTwo()
        {
            return View("Index");
        }
    }
}