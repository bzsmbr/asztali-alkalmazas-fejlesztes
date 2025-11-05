using Microsoft.AspNetCore.Http;

namespace Solution.Validators;

public class ManufacturerModelValidator : BaseValidator<ManufacturerModel>
{
    public static string NameProperty => nameof(ManufacturerModel.Name);
    public static string GlobalProperty => "Global";

    public ManufacturerModelValidator(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}

