using FluentValidation;
using Microsoft.AspNetCore.Http;
using Solution.Database.Migrations;

namespace Solution.Validators;

public class BillModelValidator: BaseValidator<BillModel>
{
    public static string BillNumberProperty => nameof(BillModel.BillNumber);
    public static string IssueDateProperty => nameof(BillModel.IssueDate);

    public static string GlobalProperty => "Global";

    public BillModelValidator(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }

        RuleFor(x => x.BillNumber).NotEmpty().WithMessage("Bill number is required");
        
        RuleFor(x => x.IssueDate).NotNull().WithMessage("Issue date is required")
                                   .InclusiveBetween(DateTime.MinValue, DateTime.Now).WithMessage("Invalid issue date");
    }
}
