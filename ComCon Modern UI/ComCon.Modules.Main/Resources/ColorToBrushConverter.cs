using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ComCon
{
    public class ColorToBrushConverter : IValueConverter
    {
        //Convert wird für die Konvertierung in das Display-Format verwendet
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom((string)value));
        }

        //ConvertBack wird verwendet, um das Display-Format in den zugrunde liegenden Wert (z.B. für die Dateneingabe) zurück zu konvertieren
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
