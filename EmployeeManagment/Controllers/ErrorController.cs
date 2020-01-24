using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagment.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger <ErrorController> logger)
        {
            this.logger = logger;
        }
        // If there is 404 status code, the route path will become Error/404
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var StatusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                //case 404:
                //    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";

                //    //ViewBag.Path = StatusCodeResult.OriginalPath;
                //    //ViewBag.QS = StatusCodeResult.OriginalQueryString;
                //    logger.LogWarning($"404 Error Occured. Path= +{StatusCodeResult.OriginalPath}" + $" and QueryString = {StatusCodeResult.OriginalQueryString}");
                //    break;

                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource could not be found";
                    // LogWarning() method logs the message under
                    // Warning category in the log
 logger.LogWarning($"404 error occured. Path ={StatusCodeResult.OriginalPath}"+ $" and QueryString ={StatusCodeResult.OriginalQueryString}");
                    break;

            }

            return View("NotFound");
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {

            // Retrieve the exception Details
            var exceptionDetails =
                    HttpContext.Features.Get<IExceptionHandlerPathFeature>();


     logger.LogError($"The path {exceptionDetails.Path}throw an exception" +$"{exceptionDetails.Error}");

            return View("Error");
        }
    }
}
