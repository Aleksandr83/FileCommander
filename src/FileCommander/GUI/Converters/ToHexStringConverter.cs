using System;
using System.Globalization;
using Agl.Helpers;
using Avalonia.Data.Converters;

namespace GUI.Converters;

public class ToHexStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {            
        return TextConvertorHelper.IntToHex(value ?? String.Empty);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {     
        return "";
    }
}
