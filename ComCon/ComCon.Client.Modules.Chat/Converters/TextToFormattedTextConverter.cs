using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;
using System.IO;
using System.Windows.Media;
using System.Windows;

namespace ComCon.Client.Modules.Chat.Converters
{
    public class TextToFormattedTextConverter : IValueConverter
    {
        //Convert wird für die Konvertierung in das Display-Format verwendet
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FlowDocument doc = new FlowDocument();

            string s = value as string;
            if (s != null)
            {
                using (StringReader reader = new StringReader(s))
                {
                    string newLine;
                    while ((newLine = reader.ReadLine()) != null)
                    {
                        Paragraph paragraph = null;
                        if (newLine.Substring(newLine.IndexOf('<')).StartsWith("Server"))
                        {
                            paragraph = new Paragraph(new Run(newLine));                            
                            paragraph.Foreground = new SolidColorBrush(Colors.Green);
                            paragraph.FontWeight = FontWeights.Normal;
                        }
                        else if (newLine.Substring(newLine.IndexOf('<')).StartsWith("Tom"))
                        {
                            paragraph = new Paragraph(new Run(newLine));
                            paragraph.Foreground = new SolidColorBrush(Colors.Red);
                            paragraph.FontWeight = FontWeights.Normal;
                        }
                        else
                        {
                            paragraph = new Paragraph(new Run(newLine));
                        }

                        doc.Blocks.Add(paragraph);
                    }
                }
            }

            return doc;
        }

        //ConvertBack wird verwendet, um das Display-Format in den zugrunde liegenden Wert (z.B. für die Dateneingabe) zurück zu konvertieren
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
