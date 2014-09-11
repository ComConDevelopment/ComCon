using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ComCon.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        //Convert wird für die Konvertierung in das Display-Format verwendet
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        //ConvertBack wird verwendet, um das Display-Format in den zugrunde liegenden Wert (z.B. für die Dateneingabe) zurück zu konvertieren
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ReverseBoolToVisibilityConverter : IValueConverter
    {
        //Convert wird für die Konvertierung in das Display-Format verwendet
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(bool)value)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        //ConvertBack wird verwendet, um das Display-Format in den zugrunde liegenden Wert (z.B. für die Dateneingabe) zurück zu konvertieren
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
