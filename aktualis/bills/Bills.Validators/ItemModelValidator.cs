using Bills.Core.Models;

namespace Bills.Validators;

public class ItemModelValidator : BaseValidator<ItemModel>
{
    public static string NameProperty => nameof(ItemModel.Name);
    public static string PriceProperty => nameof(ItemModel.Price);
    public static string AmountProperty => nameof(ItemModel.Amount);
    public static string GlobalProperty => "Global";

    public ItemModelValidator(IHttpContextAccessor httpContextAccessor = null) : base(httpContextAccessor)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!")
                            .MinimumLength(2).WithMessage("Name must be more than 2 characters!")
                            .MaximumLength(32).WithMessage("Name must be less than 32 characters!");

        RuleFor(x => x.Price).NotNull().WithMessage("Price is required")
                             .GreaterThan(0).WithMessage("Price must be greater than 0!");

        RuleFor(x => x.Amount).NotNull().WithMessage("Amount is required")
                              .GreaterThan(0).WithMessage("Amount must be greater than 0!");
    }
}
