using FluentValidation.Results;
using System.Globalization;

namespace Solution.DesktopApp.Converters;

public class ValidationResultHasErrorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo cultureInfo)
    {
        if (value is not ValidationResult validationResult || parameter == null)
        {
            return null;
        }

        if (validationResult.IsValid)
        {
            return false;
        }

        var property = parameter as string;

        return validationResult.Errors.Any(x => x.PropertyName == property);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("ConvertBack is not implemented");
    }
}
