using System.Globalization;

namespace Locksley.Converters;

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isSelected && parameter is Color color)
        {
            return isSelected ? color : Colors.Transparent;
        }
        return Colors.Transparent;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new InvalidOperationException("BoolToColorConverter can only be used OneWay.");
    }
}