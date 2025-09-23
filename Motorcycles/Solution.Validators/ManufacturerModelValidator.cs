
namespace Solution.Validators;

public class ManufacturerModelValidator : AbstractValidator<ManufacturerModel>
{
    public static string NameProperty => nameof(ManufacturerModel.Name);
    public static string GlobalProperty => "Global";

    public ManufacturerModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Manufacturer name is required!");
    }

}
