using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Solution.Shared.Extensions;

public static class ErrorOrExtension
{
    extension(ICollection<Error> errors)
    {
        public IActionResult ToProblemResult()
        {
            var modelStateDictionary = new Dictionary<string, string[]>();

            if (errors.All(e => e.Type == ErrorType.Validation))
            { 
                foreach (var error in errors)
                {
                    foreach (var kv in error.Metadata)
                    {
                        modelStateDictionary.Add(kv.Key, new[] { kv.Value.ToString()! });
                    }
                }

                return new BadRequestObjectResult(modelStateDictionary);
            }
            if (errors.Any(e => e.Type == ErrorType.Unexpected))
            {
                return new BadRequestObjectResult(errors.Select(x => x.Description));
            }

            if (errors.Any(e => e.Type == ErrorType.Failure))
            {
                return new BadRequestObjectResult(errors.Select(x => x.Description));
            }

            var firstError = errors.First();

            var statusCode = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            return new BadRequestObjectResult(errors.Select(x => x.Description)) { StatusCode = statusCode};
        }
    }
}
