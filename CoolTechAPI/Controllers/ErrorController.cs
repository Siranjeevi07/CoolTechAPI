using CoolTechAPI.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CoolTechAPI.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }
            Log.Error("An error has been occured");
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var error = $"{context.Error.Message}{Environment.NewLine}{context.Error.StackTrace}";
            return ApiResponse<string>.BadRequestObjectResult(context.Error.Message);

            //return Problem(
            //    detail: context.Error.StackTrace,
            //    title: context.Error.Message);
        }

        [Route("/error")]
        public IActionResult Error()
        {
            Log.Error("An error has been occured in the server");
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = $"{context.Error.Message}{Environment.NewLine}{context.Error.StackTrace}";
            return ApiResponse<string>.BadRequestObjectResult(context.Error.Message);
            //return ApiResponses<string>.BadRequestObjectResult("Error Occured in the system, Please reach us with your information");
        }
    }
}
