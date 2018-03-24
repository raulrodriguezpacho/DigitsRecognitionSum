using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DigitsRecognitionSum.Converters
{
    public class ResultToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "?")
                return Color.FromRgba(181, 16, 17, 255);
            else
                return Color.FromRgba(155, 218, 48, 255);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "?";
        }
    }
}
