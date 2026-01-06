using Bills.Core.Models;
using FluentValidation;

namespace Bills.Validators;

public class BillModelValidator : BaseValidator<BillModel>
{
    public static string NumberProperty => nameof(BillModel.Number);
    public static string DateProperty => nameof(BillModel.Date);
    public static string ItemsProperty => nameof(BillModel.Items);
    public static string GlobalProperty => "Global";

    public BillModelValidator(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor)
    {
        RuleFor(x => x.Number).NotEmpty().WithMessage("Number is required!")
                              .MinimumLength(2).WithMessage("Number must be more than 2 characters!")
                              .MaximumLength(32).WithMessage("Number must be less than 32 characters!");

        RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required!")
                            .LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future.");

        RuleFor(x => x.Items).NotEmpty().WithMessage("Items are required!");
    }
}
