using ErrorOr;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Solution.Core.Models.Keys;

namespace Solution.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult Problem(ICollection<Error> errors)
        {
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            if(errors.All(e => e.Type == ErrorType.Validation))
            {
                var modelStateDictionary = new ModelStateDictionary();
                foreach(var error in errors)
                {
                    modelStateDictionary.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem(modelStateDictionary);
            }

            if(errors.Any(e => e.Type == ErrorType.Unexpected))
            {
                return Problem();
            }

            var firstError = errors.First();

            var statusCode = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }
    }

    public record OkResult(bool Success = true);

}
