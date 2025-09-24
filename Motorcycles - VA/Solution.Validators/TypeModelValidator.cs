using Microsoft.AspNetCore.Http;
using Solution.Database.Migrations;

namespace Solution.Validators;

public class TypeModelValidator : BaseValidator<TypeModel>
{
    public static string NameProperty => nameof(TypeModel.Name);
    public static string GlobalProperty => "Global";

    public TypeModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}

