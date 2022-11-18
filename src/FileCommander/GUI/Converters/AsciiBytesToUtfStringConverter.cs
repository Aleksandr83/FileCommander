using System;
using System.Globalization;
using System.Text;
using alg.Helpers;
using Avalonia.Data.Converters;

namespace GUI.Converters
{
    public class AsciiBytesToUtfStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {      
            return TextConvertorHelper.AsciiBytesToUtfString((Byte[]?)value);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {           
            return "";
        }
    }
}