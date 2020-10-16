using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Bimaru.SWA.InClass
{
    public class SignToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is char)
            {
                char charValue = (char) value;
                switch (charValue) {
                    case ' ':
                        return Brushes.GhostWhite;
                    case 'O':
                        return Brushes.Aqua;
                        
                    case 'X':
                        return Brushes.BurlyWood;
                }
            }

            return Brushes.DarkGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
