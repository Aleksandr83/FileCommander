using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace GUI.Converters;

public class TextErrorColorConverter : IValueConverter
{
    static Dictionary<Color, SolidColorBrush> _Brushes = new Dictionary<Color, SolidColorBrush>();

    static TextErrorColorConverter()
    {
        _Brushes = new Dictionary<Color, SolidColorBrush>()
        {
            {Colors.Red, new SolidColorBrush(Colors.Red)},
            {Colors.LightGreen, new SolidColorBrush(Colors.LightGreen)}
        };
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {        
        Color color = Colors.LightGreen;

        if (value is bool)
        {
            bool isWasErrors = (bool) value;
            if (!isWasErrors) 
                color = Colors.Red;                    
        }      

        return _Brushes[color]; 
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
