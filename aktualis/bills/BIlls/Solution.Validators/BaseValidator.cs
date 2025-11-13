using Microsoft.AspNetCore.Http;

namespace Solution.Validators;

public abstract class BaseValidator<T>(IHttpContextAccessor httpContextAccessor) : AbstractValidator<T> where T : class
{
    private string requestMethod = httpContextAccessor?.HttpContext?.Request?.Method;

    protected bool IsPutMethod => requestMethod is not null && HttpMethods.IsPut(requestMethod);
}
