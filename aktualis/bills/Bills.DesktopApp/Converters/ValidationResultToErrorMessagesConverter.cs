namespace Bills.DesktopApp.Converters;

public class ValidationResultToErrorMessagesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || validationResult.IsValid)
        {
            return string.Empty;
        }

        if (parameter == null)
        {
            return string.Empty;
        }

        var property = parameter as string;
        var errorMessages = validationResult.Errors.Where(x => x.PropertyName == property).Select(x => x.ErrorMessage);

        return string.Join(Environment.NewLine, errorMessages);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException("ConvertBack is not implemented");
    }
}
