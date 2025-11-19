using FluentValidation;
using Microsoft.AspNetCore.Http;
using Solution.Database.Migrations;

namespace Solution.Validators;

public class ItemModelValidator: BaseValidator<ItemModel>
{
    public static string NameProperty => nameof(ItemModel.Name);
    public static string UnitPriceProperty => nameof(ItemModel.UnitPrice);
    public static string QuantityProperty => nameof(ItemModel.Quantity);

    public static string GlobalProperty => "Global";

    public ItemModelValidator(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.UnitPrice).NotNull().WithMessage("Unit Price cant be null");

        RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity cant be null");
    }
}
