using FluentValidation.Results;
using System.Globalization;

namespace Solution.DesktopApp.Converters;

public class ValidationResultToErrorMessageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || validationResult.IsValid)
        {
            return null;
        }

        if (parameter == null)
        {
            return null;
        }

        var property = parameter as string;
        var errorMessages = validationResult.Errors.Where(x => x.PropertyName == property)
                                                   .Select(x => x.ErrorMessage);

        return string.Join(Environment.NewLine, errorMessages);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException("ConvertBack is not implemented for the converter");

}
