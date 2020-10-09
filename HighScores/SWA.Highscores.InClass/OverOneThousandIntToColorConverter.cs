using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace SWA.Highscores.InClass
{
    public class OverOneThousandIntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int intValue = (int)value;
                if (intValue < 1000)
                {
                    return Brushes.Red;
                } 
                
                return Brushes.LightGreen;
            }

            return Brushes.GhostWhite;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // not used... exception is fine here
            throw new NotImplementedException();
        }
    }
}
