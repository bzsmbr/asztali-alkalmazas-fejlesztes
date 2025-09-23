
namespace Solution.Validators;

public class TypeModelValidator : AbstractValidator<TypeModel>
{
    public static string NameProperty => nameof(TypeModel.Name);
    public static string GlobalProperty => "Global";

    public TypeModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Type name is required!");
    }

}
