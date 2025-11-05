using Microsoft.AspNetCore.Http;

namespace Solution.Validators;

public class PhoneModelValidator: BaseValidator<PhoneModel>
{
    public static string ModelProperty => nameof(PhoneModel.Model);
    public static string ManufacturerProperty => nameof(PhoneModel.Manufacturer);
    public static string TypeProperty => nameof(PhoneModel.Type);
    public static string StorageInGbProperty => nameof(PhoneModel.StorageInGB);
    public static string ReleaseYearProperty => nameof(PhoneModel.ReleaseYear);
    public static string GlobalProperty => "Global";

    public PhoneModelValidator(IHttpContextAccessor httpContextAccessor): base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            //validalni h az id letezik
        }

        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required");
        
        RuleFor(x => x.Manufacturer).NotNull().WithMessage("Manufacturer is required");

        RuleFor(x => x.Manufacturer.Id).GreaterThan(0).WithMessage("Manufacturer's ID has to be greater than 0");


        RuleFor(x => x.Type).NotNull().WithMessage("Type is required");

        RuleFor(x => x.Type.Id).GreaterThan(0).WithMessage("Type's ID has to be greater than 0");

        RuleFor(x => x.StorageInGB).NotNull().WithMessage("Storage is required");

        RuleFor(x => x.ReleaseYear).NotNull().WithMessage("Release year is required")
                                   .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Invalid release year");
    }
}
